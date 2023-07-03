namespace HappyMeal.Core.Services.City
{
	using HappyMeal.Core.Services.City.Models;

	public interface ICityService
	{
		Task CreateCity(CreateCityModel model);

		Task<IEnumerable<CityModel>> GetAllCities();

		Task<int> GetCityIdByName(string cityName);
	}
}
