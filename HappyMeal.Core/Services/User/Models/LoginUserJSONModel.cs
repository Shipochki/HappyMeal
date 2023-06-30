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
	public class LoginUserJSONModel
	{
		[JsonProperty("email")]
		[Required]
		public string Email { get; set; } = null!;

		[JsonProperty("password")]
		[Required]
		public string Password { get; set; } = null!;
	}
}
