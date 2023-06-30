using HappyMeal.Core.Services.User;
using HappyMeal.Core.Services.User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

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
			LoginUserModel model = JsonConvert.DeserializeObject<LoginUserModel>(loginFormKeys.ToString());

			return Ok(await this._userService.Login(model.Email, model.Password));
		}

		
	}
}
