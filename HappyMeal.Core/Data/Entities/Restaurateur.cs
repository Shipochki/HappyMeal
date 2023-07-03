namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Restaurateur
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey(nameof(User))]		
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public HashSet<Restaurant> Restaurants { get; set;} = new HashSet<Restaurant>();

		public bool IsActive { get; set; } = false;
	}
}
