using HappyMeal.Core.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyMeal.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost]
		[Route("[action]")]
		public async Task<IActionResult> AddProduct([FromBody] object createFormKeys)
		{
			return Ok(await this._productService.AddProduct(createFormKeys));
		}
	}
}
