using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HappyMeal.Core.Common.DataConstatnts.UserConst;


namespace HappyMeal.Core.Services.User.Models
{
	[JsonObject]
	public class RegisterUserJSONModel
	{
		[JsonProperty("firstname")]
		[MinLength(MinLengthFirstName)]
		[MaxLength(MaxLengthFirstName)]
		public string FirstName { get; set; } = null!;

		[JsonProperty("lastname")]
		[MinLength(MinLengthLastName)]
		[MaxLength(MaxLengthLastName)]
		public string LastName { get; set; } = null!;

		[JsonProperty("phonenumber")]
		[MinLength(MinLengthPhoneNumber)]
		[MaxLength(MaxLengthPhoneNumber)]
		public string PhoneNumber { get; set; } = null!;

		[JsonProperty("email")]
		[MinLength(MinLengthEmail)]
		[MaxLength(MaxLengthEmail)]
		public string Email { get; set; } = null!;

		[JsonProperty("password")]
		[MinLength(MinLengthPassword)]
		[MaxLength(MaxLengthPassword)]
		public string Password { get; set; } = null!;
	}
}
