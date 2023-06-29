using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.Cart.Models
{
	public class CreateCartModel
	{
		public int UserId { get; set; }

		public decimal DeliveryCosts { get; set; }

		public decimal Subtotal { get; set; }
	}
}
