using HappyMeal.Core.Services.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyMeal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ICartService _cartService;

		public CartController(ICartService cartService)
		{
			_cartService = cartService;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> GetCartByUserId(int userId) 
		{
			return Ok(await this._cartService.GetCartByUserId(userId));
		}
	}
}
