namespace HappyMeal.Core.Services.Cart
{
	using HappyMeal.Core.Services.Cart.Models;

	public interface ICartService
	{
		Task<int> GetLastCartId();

		Task CreateCart(int userId);

		Task<CartModel> GetCartByUserId(int userId);

		Task<CartModel> AddProductToCart(object data);
	}
}
