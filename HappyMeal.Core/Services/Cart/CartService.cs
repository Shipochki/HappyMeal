namespace HappyMeal.Core.Services.Cart
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.Cart.Models;
	using HappyMeal.Core.Services.Product.Models;
	using Microsoft.EntityFrameworkCore;

	public class CartService : ICartService
	{
		private HappyMealDbContext _context;

		public CartService(HappyMealDbContext context)
		{
			_context = context;
		}

		public async Task CreateCart(int userId)
		{
			Cart cart = new Cart()
			{
				UserId = userId,
				DeliveryCosts = 0,
				Subtotal = 0,
			};

			await this._context.Carts.AddAsync(cart);
			await this._context.SaveChangesAsync();
		}

		public async Task<CartModel> GetCartByUserId(int userId)
		{
			CartModel? model = await this._context
				.Carts
				.Where(c => c.UserId == userId)
				.Select(c => new CartModel()
				{
					UserId = userId,
					Products = c.CartsProducts
						.Where(cp => cp.CartId == c.Id)
						.Select(cp => new ProductModel()
						{
							Id = cp.Product.Id,
							Name = cp.Product.Name,
							Description = cp.Product.Description,
							Type = cp.Product.Type.ToString(),
							Price = cp.Product.Price,
							Weight = cp.Product.Weight,
						})
						.ToList(),
					DeliveryCosts = 5,
					Subtotal = 0,
				})
				.FirstOrDefaultAsync();

			if(model == null)
			{
				return null;
			}

			model.Subtotal = model.Products.Sum(p => p.Price);

			return model;
		}

		public async Task<int> GetLastCartId()
		{
			List<Cart> carts = await this._context
				.Carts
				.ToListAsync();

			if(carts == null)
			{
				return 0;
			}

			return carts.Count;
		}
	}
}
