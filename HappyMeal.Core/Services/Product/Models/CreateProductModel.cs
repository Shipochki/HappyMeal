namespace HappyMeal.Core.Services.Product.Models
{
	using HappyMeal.Core.Data.Enums;
	using System.ComponentModel.DataAnnotations;
	using static HappyMeal.Core.Common.DataConstatnts.ProductConst;
	public class CreateProductModel
	{
		[Required]
		[MinLength(MinLengthName)]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(MinLengthDescription)]
		[MaxLength(MaxLengthDescription)]
		public string Description { get; set; } = null!;

		[Required]
		[Range(MinRangeTypeProduct, MaxRangeTypeProduct)]
		public TypeProduct Type { get; set; }

		[Required]
		[Range(0, 1000)]
		public decimal Price { get; set; }

		[Required]
		[MinLength(MinLengthWeight)]
		[MaxLength(MaxLengthWeight)]
		public string? Weight { get; set; } 
	}
}
