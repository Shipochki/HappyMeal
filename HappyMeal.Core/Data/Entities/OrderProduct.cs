﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class OrderProduct
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(Order))]
		public int OrderId { get; set; }

		public Order Order { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		public Product Product { get; set; } = null!;
	}
}
