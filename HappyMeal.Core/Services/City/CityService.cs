namespace HappyMeal.Core.Services.City
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.City.Models;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;

	public class CityService : ICityService
	{
		private HappyMealDbContext _context;

		public CityService(HappyMealDbContext context)
		{
			this._context = context;
		}

		public async Task CreateCity(CreateCityModel model)
		{
			City city = new City()
			{
				Name = model.Name,
			}; 

			await this._context.AddAsync(city);
			await this._context.SaveChangesAsync();
		}

		public async Task<IEnumerable<CityModel>> GetAllCities()
		{
			IEnumerable<CityModel> cities = await this._context
				.Cities
				.Select(c => new CityModel()
				{
					Id = c.Id,
					Name = c.Name,
				})
				.ToListAsync();

			return cities;
		}
	}
}
