namespace HappyMeal.Core.Services.Review
{
	using Microsoft.EntityFrameworkCore;

	public class ReviewService : IReviewService
	{
		private readonly HappyMealDbContext _context;

		public ReviewService(HappyMealDbContext context)
		{
			_context = context;
		}

		public async Task<double> GetAverageRatingByRestaurantId(int restaurantId)
		{
			if(this._context.Reviews != null)
			{
				return await this._context
				.Reviews
				.Where(r => r.RestaurantId == restaurantId)
				.AverageAsync(r => r.Rating);
			}

			return 0;
		}
	}
}
