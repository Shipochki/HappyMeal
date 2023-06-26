using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class Admin
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string Name { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(User))]
		public int UserId { get; set; }

		public User User { get; set; } = null!;
	}
}
