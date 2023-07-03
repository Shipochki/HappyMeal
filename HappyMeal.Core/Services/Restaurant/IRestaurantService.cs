using HappyMeal.Core.Services.Restaurant.Models;

namespace HappyMeal.Core.Services.Restaurant
{
	public interface IRestaurantService
	{
		Task<List<RestaurantModel>> AllByCity(string city);

		Task<List<RestaurantModel>> All();

		Task<int> CreateRestaurant(object data);

		Task<DetailsRestaurantModel> GetRestaurantById(int id);
	}
}
