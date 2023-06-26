namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class CartProduct
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(Cart))]
		public int CartId { get; set; }
		public Cart Cart { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }
		public Product Product { get; set; } = null!;
	}
}
