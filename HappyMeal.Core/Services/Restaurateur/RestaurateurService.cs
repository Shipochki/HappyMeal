namespace HappyMeal.Core.Services.Restaurateur
{
	using HappyMeal.Core.Data.Entities;
	using Microsoft.EntityFrameworkCore;

	public class RestaurateurService : IRestaurateurService
	{
		private readonly HappyMealDbContext _context;

		public RestaurateurService(HappyMealDbContext context)
		{
			_context = context;
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
