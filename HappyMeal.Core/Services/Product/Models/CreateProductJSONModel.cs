namespace HappyMeal.Core.Services.Product.Models
{
	using HappyMeal.Core.Data.Enums;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using static HappyMeal.Core.Common.DataConstatnts.ProductConst;

	[JsonObject]
	public class CreateProductJSONModel
	{
		[Required]
		[JsonProperty("name")]
		[MinLength(MinLengthName)]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[Required]
		[JsonProperty("description")]
		[MinLength(MinLengthDescription)]
		[MaxLength(MaxLengthDescription)]
		public string Description { get; set; } = null!;

		[Required]
		[JsonProperty("type")]
		[Range(MinRangeTypeProduct, MaxRangeTypeProduct)]
		public int Type { get; set; }

		[Required]
		[JsonProperty("price")]
		[Range(0, 1000)]
		public decimal Price { get; set; }

		[Required]
		[JsonProperty("weight")]
		[MinLength(MinLengthWeight)]
		[MaxLength(MaxLengthWeight)]
		public string? Weight { get; set; }

		[Required]
		[JsonProperty("restaurantId")]
		public int RestaurantId { get; set; }
	}
}
