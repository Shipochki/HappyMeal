using HappyMeal.Core.Services.Product.Models;

namespace HappyMeal.Core.Services.Cart.Models
{

	public class CartModel
	{
		public int UserId { get; set; }

		public List<ProductModel> Products { get; set; }

		public decimal DeliveryCosts { get; set; }

		public decimal Subtotal { get; set; }
	}
}
