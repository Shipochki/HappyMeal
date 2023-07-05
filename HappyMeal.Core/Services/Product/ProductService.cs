namespace HappyMeal.Core.Services.Product
{
	public class ProductService
	{
		private readonly HappyMealDbContext _context;

		public ProductService(HappyMealDbContext context)
		{
			_context = context;
		}


	}
}
