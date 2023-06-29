namespace HappyMeal.Core.Services.User
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.Cart;
	using HappyMeal.Core.Services.User.Models;
	using Microsoft.EntityFrameworkCore;
	using static HappyMeal.Core.Common.TokenGenerator;

	public class UserService : IUserService
	{
		private HappyMealDbContext _context;
		private ICartService _cartService;

		public UserService(HappyMealDbContext context, ICartService cartService)
		{
			_context = context;
			_cartService = cartService;
		}

		public async Task<UserModel> Login(string email, string password)
		{
			User user = await this._context
				.Users
				.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null)
			{
				return null;
			}

			if (user.Password != password)
			{
				return null;
			}

			UserModel model = new UserModel()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = email,
				AccessToken = RandomToken(30)
			};

			return model;
		}

		public async Task<UserModel> Register(CreateUserModel model)
		{
			User user = await this._context
				.Users
				.FirstOrDefaultAsync(u => u.Email == model.Email);

			if (user != null)
			{
				return null;
			}

			int cartId = await this._cartService.GetLastCartId() + 1;

			User newUser = new User()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Password = model.Password,
				PhoneNumber = model.PhoneNumber,
				CartId = cartId,
			};

			await this._context.Users.AddAsync(newUser);
			await this._context.SaveChangesAsync();

			await this._cartService.CreateCart(newUser.Id);

			UserModel result = new UserModel()
			{
				Id = newUser.Id,
				FirstName = newUser.FirstName,
				LastName = newUser.LastName,
				Email = newUser.Email,
				AccessToken = RandomToken(30)
			};

			return result;
		}
	}
}
