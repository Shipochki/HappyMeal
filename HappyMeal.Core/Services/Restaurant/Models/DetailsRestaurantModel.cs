using HappyMeal.Core.Services.Product.Models;

namespace HappyMeal.Core.Services.Restaurant.Models
{
	public class DetailsRestaurantModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string? ImgLinkUrl { get; set; }

		public int DeliveryTime { get; set; }

		public decimal MinMoneyForOrder { get; set; }

		public int OwnerId { get; set; }

		public List<CreateProductModel> Products { get; set; }
	}
}
