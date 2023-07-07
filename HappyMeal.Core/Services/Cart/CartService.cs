namespace HappyMeal.Core.Services.Cart
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.Cart.Models;
	using HappyMeal.Core.Services.Product;
	using HappyMeal.Core.Services.Product.Models;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;

	public class CartService : ICartService
	{
		private HappyMealDbContext _context;
		private readonly IProductService _productService;

		public CartService(HappyMealDbContext context,
			IProductService productService)
		{
			_context = context;
			_productService = productService;
		}

		public async Task<CartModel> AddProductToCart(object data)
		{
			ProductToCartJSONModel? model = JsonConvert.DeserializeObject<ProductToCartJSONModel>(data.ToString());

			if(model == null )
			{
				return null;
			}

			Cart? cart = await this._context.Carts.FirstOrDefaultAsync(c => c.UserId == model.UserId);

			if( cart == null )
			{
				return null;
			}

			await this._context.CartsProducts.AddAsync(new CartProduct { ProductId = model.ProductId, CartId = cart.Id });

			await this._context.SaveChangesAsync();

			return await GetCartByUserId(model.UserId);
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

		public async Task<CartModel> RemoveProductFromCart(object data)
		{
			ProductToCartJSONModel? model = JsonConvert.DeserializeObject<ProductToCartJSONModel>(data.ToString());

			if (model == null)
			{
				return null;
			}

			Cart? cart = await this._context
				.Carts
				.FirstOrDefaultAsync(c => c.UserId == model.UserId);

			if (cart == null)
			{
				return null;
			}

			CartProduct? cartProduct = await this._context
				.CartsProducts
				.FirstOrDefaultAsync(cp => cp.CartId == cart.Id 
				&& cp.ProductId == model.ProductId);


			if (cartProduct == null)
			{
				return null;
			}

			this._context.CartsProducts.Remove(cartProduct);
			await this._context.SaveChangesAsync();

			return await GetCartByUserId(model.UserId);
		}
	}
}
