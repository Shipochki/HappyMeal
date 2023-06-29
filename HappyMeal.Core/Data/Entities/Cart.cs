namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Cart
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public HashSet<CartProduct> CartsProducts { get; set; } = new HashSet<CartProduct>();

		[Required]
		public decimal DeliveryCosts { get; set; }

		[Required]
		public decimal Subtotal { get; set; }
	}
}
