namespace HappyMeal.Core.Services.Product
{
	using HappyMeal.Core.Services.Product.Models;
	public interface IProductService
	{
		Task<int> AddProduct(object product);
	}
}
