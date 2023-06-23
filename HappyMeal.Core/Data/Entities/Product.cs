using HappyMeal.Core.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace HappyMeal.Core.Data.Entities
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public TypeProduct Type { get; set; }

		[Required]
		public string Description { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public string Weight { get; set; } = null!; 

		//Restaurant Id

		//Addons

		//Ordered Products

		//Carts Products

		public bool InStock { get; set; }

		public bool IsActive { get; set; }
	}
}
