namespace HappyMeal.Core.Services.City.Models
{
	using System.ComponentModel.DataAnnotations;
	using static HappyMeal.Core.Common.DataConstatnts.CityConst;

	public class CreateCityModel
	{
		[Required]
		[MinLength(MinLengthName)]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;
	}
}
