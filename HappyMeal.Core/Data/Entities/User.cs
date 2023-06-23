using System.ComponentModel.DataAnnotations;
using static HappyMeal.Core.Common.DataConstatnts.UserConst;

namespace HappyMeal.Core.Data.Entities
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxLengthFirstName)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthLastName)]
		public string LastName { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthPhoneNumber)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[MaxLength(MaxLengthEmail)]
		public string Email { get; set; } = null!;

		public HashSet<Review> Reviews { get; set; } = new HashSet<Review>();

		public bool IsActive { get; set; } = true;
	}
}
