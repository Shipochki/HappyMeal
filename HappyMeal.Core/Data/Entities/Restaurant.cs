namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static HappyMeal.Core.Common.DataConstatnts.RestaurantConst;

	public class Restaurant
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthDescription)]
		public string Description { get; set; } = null!;

		public string? ImgLinkUrl { get; set; }

		[Required]
		public int DeliveryTime { get; set; }

		[Required]
		public decimal MinMoneyForOrder { get; set; }

		[Required]
		[ForeignKey(nameof(Restaurateur))]
		public int OwnerId { get; set; }
		public Restaurateur Restaurateur { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(City))]
		public int CityId { get; set; }
		public City City { get; set; } = null!;

		public HashSet<Product> Products { get; set; } = new HashSet<Product>();

		public HashSet<Review> Reviews { get; set; } = new HashSet<Review>();

		public HashSet<Order> Orders { get; set; } = new HashSet<Order>();

		public bool IsActive { get; set; }
	}
}
