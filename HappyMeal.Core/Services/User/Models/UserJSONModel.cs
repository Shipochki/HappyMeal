using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.User.Models
{
	[JsonObject]
	public class UserJSONModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("firstname")]
		public string FirstName { get; set; }

		[JsonProperty("lastname")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("accesstoken")]
		public string AccessToken { get; set; }

		[JsonProperty("isrestaurateur")]
		public bool IsRestaurateur { get; set; }

		[JsonProperty("isadmin")]
		public bool IsAdmin { get; set; }
	}
}
