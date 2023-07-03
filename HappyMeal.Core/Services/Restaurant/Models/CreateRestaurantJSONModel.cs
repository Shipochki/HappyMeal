using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static HappyMeal.Core.Common.DataConstatnts.RestaurantConst;
using Newtonsoft.Json;

namespace HappyMeal.Core.Services.Restaurant.Models
{
	[JsonObject]
	public class CreateRestaurantJSONModel
	{
		[JsonProperty("name")]
		[MinLength(MinLengthName)]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[JsonProperty("description")]
		[MinLength(MinLengthDescription)]
		[MaxLength(MaxLengthDescription)]
		public string Description { get; set; } = null!;

		[JsonProperty("imgUrlLink")]
		public string? ImgLinkUrl { get; set; }

		[JsonProperty("deliveryTime")]
		public int DeliveryTime { get; set; }

		[JsonProperty("minMoneyForOrder")]
		public decimal MinMoneyForOrder { get; set; }

		[JsonProperty("ownerId")]
		public int OwnerId { get; set; }

		[JsonProperty("cityName")]
		public string CityName { get; set; }
	}
}
