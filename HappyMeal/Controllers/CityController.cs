using HappyMeal.Core.Services.City;
using Microsoft.AspNetCore.Mvc;

namespace HappyMeal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
		{
			_cityService = cityService;
		}

		[HttpGet]
		[Route("[action]")]
		public async Task<IActionResult> All()
		{
			return Ok(await this._cityService.GetAllCities());
		}
	}
}
