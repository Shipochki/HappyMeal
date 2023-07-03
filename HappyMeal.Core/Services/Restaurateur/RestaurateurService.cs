namespace HappyMeal.Core.Services.Restaurateur
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.Restaurateur.Models;
	using HappyMeal.Core.Services.User.Models;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using System.Collections.Generic;

	public class RestaurateurService : IRestaurateurService
	{
		private readonly HappyMealDbContext _context;

		public RestaurateurService(HappyMealDbContext context)
		{
			_context = context;
		}

		public async Task Become(object auth)
		{
			UserJSONModel model = JsonConvert.DeserializeObject<UserJSONModel>(auth.ToString());

			if (model.IsRestaurateur)
			{
				return;
			}

			Restaurateur restaurateur = new Restaurateur()
			{
				UserId = model.Id,
			};

			await this._context.Restaurateurs.AddAsync(restaurateur);
			await this._context.SaveChangesAsync();
		}

		public async Task<List<RestaurateurModel>> GetAllCandidates()
		{
			return await this._context
				.Restaurateurs
				.Where(r => r.IsActive == false)
				.Select(r => new RestaurateurModel()
				{
					Id = r.Id,
					FullName = $"{r.User.FirstName} {r.User.LastName}",
					PhoneNumber = r.User.PhoneNumber,
					Email = r.User.Email,
					IsActive = r.IsActive,
				})
				.ToListAsync();
		}

		public async Task<bool> IsRestaurateur(int userId)
		{
			Restaurateur restaurateur = await this._context
				.Restaurateurs
				.FirstOrDefaultAsync(r => r.UserId == userId && r.IsActive);

			if(restaurateur == null)
			{
				return false;
			}

			return true;
		}

		public async Task<bool> IsCandidate(int userId)
		{
			Restaurateur restaurateur = await this._context
				.Restaurateurs
				.FirstOrDefaultAsync(r => r.UserId == userId && r.IsActive == false);

			if (restaurateur == null)
			{
				return false;
			}

			return true;
		}
	}
}
