using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.User.Models
{
	[JsonObject]
	public class RegisterUserJSONModel
	{
		[JsonProperty("firstname")]
		public string FirstName { get; set; } = null!;

		[JsonProperty("lastname")]
		public string LastName { get; set; } = null!;

		[JsonProperty("phonenumber")]
		public string PhoneNumber { get; set; } = null!;

		[JsonProperty("email")]
		public string Email { get; set; } = null!;

		[JsonProperty("password")]
		public string Password { get; set; } = null!;
	}
}
