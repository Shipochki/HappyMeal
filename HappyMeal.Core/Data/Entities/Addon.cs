using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HappyMeal.Core.Common.DataConstatnts.AddonConst;

namespace HappyMeal.Core.Data.Entities
{
	public class Addon
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthName)]
		public string Name { get; set; } = null!;

		[MaxLength(MaxLengthDescription)]
		public string? Description { get; set; }

		[MaxLength(MaxLengthWeight)]
		public string? Weight { get; set; }

		public decimal Price { get; set; }

		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		public Product Product { get; set; } = null!;
	}
}
