using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.User.Models
{
	public class UserModel
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }	

		public string AccessToken { get; set; }

		public bool IsRestaurateur { get; set; }

		public bool IsCandidate { get; set; }

		public bool IsAdmin { get; set; }
	}
}
