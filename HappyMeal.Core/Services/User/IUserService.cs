namespace HappyMeal.Core.Services.User
{
	using HappyMeal.Core.Services.User.Models;

	public interface IUserService
	{
		Task<UserModel> Login(string email, string password);

		Task<UserModel> Register(CreateUserModel model);
	}
}
