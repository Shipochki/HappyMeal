namespace HappyMeal.Core.Services.User
{
	using HappyMeal.Core.Services.User.Models;

	public interface IUserService
	{
		Task<UserModel> Login(object loginFormKeys);

		Task<UserModel> Register(object registerFormKeys);
	}
}
