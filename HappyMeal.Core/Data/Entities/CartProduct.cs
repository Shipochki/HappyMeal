using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class CartProduct
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(Cart))]
		public int CartId { get; set; }
		public Cart Cart { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }
		public Product Product { get; set; } = null!;
	}
}
