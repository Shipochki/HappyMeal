namespace HappyMeal.Core.Services.Product
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Data.Enums;
	using HappyMeal.Core.Services.Product.Models;
	using Newtonsoft.Json;

	public class ProductService : IProductService
	{
		private readonly HappyMealDbContext _context;

		public ProductService(HappyMealDbContext context)
		{
			_context = context;
		}

		public async Task<int> AddProduct(object createFormKeys)
		{
			CreateProductJSONModel? model = JsonConvert.DeserializeObject<CreateProductJSONModel>(createFormKeys.ToString());

			if(model == null)
			{
				return -1;
			}

			Product newProduct = new Product()
			{
				Name = model.Name,
				Description = model.Description,
				Type = (TypeProduct)model.Type,
				Price = model.Price,
				Weight = model.Weight,
				RestaurantId = model.RestaurantId,
			};

			await this._context.Products.AddAsync(newProduct);

			await this._context.SaveChangesAsync();

			return newProduct.Id;
		}
	}
}
