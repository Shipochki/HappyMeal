namespace HappyMeal.Core.Services.Cart
{
	using HappyMeal.Core.Data.Entities;
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
