using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMeal.Core.Common.DataConstatnts.RestaurantConst;

namespace HappyMeal.Core.Data.Entities
{
	public class Restaurant
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthDescription)]
		public string Description { get; set; } = null!;

		[Required]
		public int DeliveryTime { get; set; }

		[Required]
		public decimal MinMoneyForOrder { get; set; }

		//Owner Id

		[ForeignKey(nameof(City))]
		public int CityId { get; set; }
		public City City { get; set; } = null!;

		//Products

		//Reviews

		public bool IsActive { get; set; }
	}
}
