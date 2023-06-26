namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class OrderProduct
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(Order))]
		public int OrderId { get; set; }

		public Order Order { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		public Product Product { get; set; } = null!;
	}
}
