using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class Cart
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public HashSet<CartProduct> CartsProducts { get; set; } = new HashSet<CartProduct>();

		public decimal DeliveryCosts { get; set; }

		public decimal Subtotal { get; set; }
	}
}
