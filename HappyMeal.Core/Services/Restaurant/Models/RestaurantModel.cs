namespace HappyMeal.Core.Services.Restaurant.Models
{
	public class RestaurantModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImgUrlLink { get; set; }

		public int DeliveryTime { get; set; }

		public decimal MinMoneyForOrder { get; set; } 

		public double Rating { get; set; }

	}
}
