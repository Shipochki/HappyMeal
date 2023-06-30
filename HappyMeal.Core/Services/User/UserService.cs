namespace HappyMeal.Core.Services.User
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.Admin;
	using HappyMeal.Core.Services.Cart;
	using HappyMeal.Core.Services.Restaurateur;
	using HappyMeal.Core.Services.User.Models;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;
	using static HappyMeal.Core.Common.TokenGenerator;
	using static HappyMeal.Core.Common.Validation;

	public class UserService : IUserService
	{
		private readonly HappyMealDbContext _context;
		private readonly ICartService _cartService;
		private readonly IRestaurateurService _restaurateurService;
		private readonly IAdminService _adminService;

		public UserService(HappyMealDbContext context, 
			ICartService cartService, 
			IRestaurateurService restaurateurService,
			IAdminService adminService)
		{
			_context = context;
			_cartService = cartService;
			_restaurateurService = restaurateurService;
			_adminService = adminService;
		}

		public async Task<UserModel> Login(object loginFormKeys)
		{
			LoginUserJSONModel model = JsonConvert.DeserializeObject<LoginUserJSONModel>(loginFormKeys.ToString());

			if (model == null || !IsValid(model))
			{
				return null;
			}

			User user = await this._context
				.Users
				.FirstOrDefaultAsync(u => u.Email == model.Email);

			if (user == null)
			{
				return null;
			}

			if (user.Password != model.Password)
			{
				return null;
			}

			bool isRestaurateur = await this._restaurateurService.IsRestaurateur(user.Id);
			bool isAdmin = await this._adminService.IsAdmin(user.Id);

			UserModel result = new UserModel()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				AccessToken = RandomToken(30),
				IsRestaurateur = isRestaurateur,
				IsAdmin = isAdmin
			};

			return result;
		}

		public async Task<UserModel> Register(object registerFormKeys)
		{
			RegisterUserJSONModel model = JsonConvert.DeserializeObject<RegisterUserJSONModel>(registerFormKeys.ToString());

			if (model == null || !IsValid(model))
			{
				return null;
			}

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
				AccessToken = RandomToken(30),
				IsRestaurateur = false,
				IsAdmin = false,
			};

			return result;
		}
	}
}
