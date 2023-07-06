namespace HappyMeal.Core.Services.Cart.Models
{
	using Newtonsoft.Json;

	[JsonObject]
	public class AddProductToCartJSONModel
	{
		[JsonProperty("productId")]
		public int ProductId { get; set; }

		[JsonProperty("userId")]
		public int UserId { get; set; }
	}
}
