namespace HappyMeal.Controllers
{
	using HappyMeal.Core.Services.Restaurateur;
	using Microsoft.AspNetCore.Mvc;

	[Route("api/[controller]")]
	[ApiController]
	public class RestaurateurController : ControllerBase
	{
		private readonly IRestaurateurService _restaurateurService;

		public RestaurateurController(IRestaurateurService restaurateurService)
		{
			_restaurateurService = restaurateurService;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> Become([FromBody]object auth)
		{
			await this._restaurateurService.Become(auth);
			return Ok();
		}

		[HttpGet]
		[Route("[action]")]
		public async Task<IActionResult> GetAllCandidates()
		{
			return Ok(await this._restaurateurService.GetAllCandidates());
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> ApproveCandidate([FromBody]int id)
		{
			await this._restaurateurService.ApproveCandidate(id);
			return Ok();
		}
	}
}
