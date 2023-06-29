namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Restaurant))]
		public int RestaurantId { get; set; }

		public Restaurant Restaurant { get; set; } = null!;

		[Required]
		public decimal Subtotal { get; set; }
	}
}
