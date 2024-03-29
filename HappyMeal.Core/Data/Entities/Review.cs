﻿namespace HappyMeal.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static HappyMeal.Core.Common.DataConstatnts.ReviewConst;

	public class Review
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(MaxLenghtComment)]
		public string? Comment { get; set; }

		[Required]
		public int Rating { get; set; }

		[Required]
		[ForeignKey(nameof(User))]
	    public int UserId { get; set; }
		public User User { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Restaurant))]
		public int RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; } = null!;

		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public bool IsActive { get; set; } = false;
	}
}
