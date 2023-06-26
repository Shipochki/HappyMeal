namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using static HappyMeal.Core.Common.DataConstatnts.UserConst;

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

		public HashSet<Order> Orders { get; set; } = new HashSet<Order>();

		public int CartId { get; set; }
		public Cart Cart { get; set; } = null!;

		public bool IsActive { get; set; } = true;
	}
}
