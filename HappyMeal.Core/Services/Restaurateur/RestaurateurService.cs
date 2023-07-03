namespace HappyMeal.Core.Services.Restaurateur
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.User.Models;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;

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

		public async Task<bool> IsRestaurateur(int userId)
		{
			Restaurateur restaurateur = await this._context
				.Restaurateurs
				.FirstOrDefaultAsync(r => r.UserId == userId);

			if(restaurateur == null)
			{
				return false;
			}

			return true;
		}
	}
}
