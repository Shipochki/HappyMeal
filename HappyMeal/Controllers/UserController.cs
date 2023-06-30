using HappyMeal.Core.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace HappyMeal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> Login([FromBody]object loginFormKeys)
		{
			return Ok(await this._userService.Login(loginFormKeys));
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> Register([FromBody]object registerFormKeys)
		{
			return Ok(await this._userService.Register(registerFormKeys));
		}
	}
}
