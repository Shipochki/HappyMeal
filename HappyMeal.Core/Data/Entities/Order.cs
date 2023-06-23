using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Restaurant))]
		public int RestaurantID { get; set; }

		public Restaurant Restaurant { get; set; } = null!;

		public decimal Subtotal { get; set; }
	}
}
