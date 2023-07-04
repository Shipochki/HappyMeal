using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.Review
{
	public interface IReviewService
	{
		Task<double> GetAverageRatingByRestaurantId(int restaurantId);
	}
}
