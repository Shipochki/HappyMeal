﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.Product.Models
{
	public class ProductModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Type { get; set; }

		public decimal Price { get; set; }	

		public string? Weight { get; set; }
	}
}
