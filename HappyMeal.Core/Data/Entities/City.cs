using System.ComponentModel.DataAnnotations;
using static HappyMeal.Core.Common.DataConstatnts.CityConst;

namespace HappyMeal.Core.Data.Entities
{
	public class City
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		public HashSet<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();
	}
}
