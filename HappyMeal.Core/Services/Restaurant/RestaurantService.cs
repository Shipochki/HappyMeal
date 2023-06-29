using HappyMeal.Core.Data.Entities;
using HappyMeal.Core.Services.Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyMeal.Core.Services.Restaurant
{
	public class RestaurantService : IRestaurantService
	{
		HappyMealDbContext _context;

		public RestaurantService(HappyMealDbContext context)
		{
			_context = context;
		}

		public async Task<List<RestaurantModel>> All()
		{
			return await this._context.Restaurants
				.Select(r => new RestaurantModel
				{
					Id = r.Id,
					Name = r.Name,
					DeliveryTime = r.DeliveryTime,
					MinMoneyForOrder = r.MinMoneyForOrder,
					Rating = r.Reviews.Average(r => r.Rating)
				})
				.ToListAsync();
		}

		public async Task<List<RestaurantModel>> AllByCity(string city)
		{
			return await this._context.Restaurants
				.Where(r => r.City.Name == city)
				.Select(r => new RestaurantModel
				{
					Id = r.Id,
					Name = r.Name,
					DeliveryTime = r.DeliveryTime,
					MinMoneyForOrder = r.MinMoneyForOrder,
					Rating = r.Reviews.Average(r => r.Rating)
				})
				.ToListAsync();
		}
	}
}
