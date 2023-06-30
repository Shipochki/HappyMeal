namespace HappyMeal.Core.Services.Admin
{
	using HappyMeal.Core.Data.Entities;
	using Microsoft.EntityFrameworkCore;

	public class AdminService : IAdminService
	{
		private readonly HappyMealDbContext _context;

		public AdminService(HappyMealDbContext context)
		{
			_context = context;
		}

		public async Task<bool> IsAdmin(int userId)
		{
			Admin admin = await this._context
				.Admins
				.FirstOrDefaultAsync(a => a.UserId == userId);

			if(admin == null)
			{
				return false;
			}

			return true;
		}
	}
}
