using HappyMeal.Core.Services.City;
using Microsoft.AspNetCore.Http;
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
		public IActionResult All()
		{
			return Ok(10);
		}
	}
}
