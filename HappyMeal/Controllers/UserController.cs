using HappyMeal.Core.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyMeal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> Login([FromBody] object obj)
		{
			return Ok(10);
		}
	}
}
