namespace HappyMeal.Core.Data.Entities
{
	using HappyMeal.Core.Data.Enums;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static HappyMeal.Core.Common.DataConstatnts.ProductConst;

	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[Required]
		public TypeProduct Type { get; set; }

		[Required]
		[MaxLength(MaxLengthDescription)]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		[MaxLength(MaxLengthWeight)]
		public string? Weight { get; set; }

		[Required]
		[ForeignKey(nameof(Restaurant))]
		public int RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; } = null!;

		public HashSet<Addon> Addons { get; set; } = new HashSet<Addon>();

		public HashSet<OrderProduct> OrderedProducts { get; set; } = new HashSet<OrderProduct>();

		public HashSet<CartProduct> CartsProducts { get; set; } = new HashSet<CartProduct>();

		public bool InStock { get; set; } = true;

		public bool IsActive { get; set; } = false;
	}
}
