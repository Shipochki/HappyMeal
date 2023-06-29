using HappyMeal.Core.Services.Restaurant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyMeal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestaurantController : ControllerBase
	{
		private IRestaurantService _restaurantService;

		public RestaurantController(IRestaurantService restaurantService)
		{
			_restaurantService = restaurantService;
		}

		[HttpGet]
		[Route("[action]")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await this._restaurantService.All());
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> GetAllByCity([FromBody]string city)
		{
			return Ok(await this._restaurantService.AllByCity(city));
		}
	}
}
