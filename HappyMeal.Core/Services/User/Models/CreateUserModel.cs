using HappyMeal.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.User.Models
{
	public class CreateUserModel
	{
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public int CartId { get; set; }

		public bool IsActive { get; set; } = true;
	}
}
