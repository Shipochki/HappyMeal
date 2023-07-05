namespace HappyMeal.Core.Services.Restaurant
{
	using HappyMeal.Core.Data.Entities;
	using HappyMeal.Core.Services.City;
	using HappyMeal.Core.Services.Product.Models;
	using HappyMeal.Core.Services.Restaurant.Models;
	using HappyMeal.Core.Services.Restaurateur;
	using HappyMeal.Core.Services.Review;
	using Microsoft.EntityFrameworkCore;
	using Newtonsoft.Json;

	public class RestaurantService : IRestaurantService
	{
		private readonly HappyMealDbContext _context;
		private readonly ICityService _cityService;
		private readonly IRestaurateurService _restaurateurService;
		private readonly IReviewService _reviewService;

		public RestaurantService(HappyMealDbContext context, 
			ICityService cityService,
			IRestaurateurService restaurateurService,
			IReviewService reviewService)
		{
			_context = context;
			_cityService = cityService;
			_restaurateurService = restaurateurService;
			_reviewService = reviewService;
		}

		public async Task<List<RestaurantModel>> All()
		{
			return await this._context.Restaurants
				.Select(r => new RestaurantModel
				{
					Id = r.Id,
					Name = r.Name,
					DeliveryTime = r.DeliveryTime,
					MinMoneyForOrder = r.MinMoneyForOrder,
					ImgUrlLink = r.ImgLinkUrl,
					Rating = r.Reviews.Average(r => r.Rating)
				})
				.ToListAsync();
		}

		public async Task<List<RestaurantModel>> AllByCity(string city)
		{
			List<RestaurantModel> result = await this._context.Restaurants
				.Include(r => r.Reviews)
				.Where(r => r.City.Name.ToLower() == city.ToLower())
				.Select(r => new RestaurantModel
				{
					Id = r.Id,
					Name = r.Name,
					DeliveryTime = r.DeliveryTime,
					MinMoneyForOrder = r.MinMoneyForOrder,
					ImgUrlLink = r.ImgLinkUrl,
					Rating = 0
				})
				.ToListAsync();

			return result;
		}

		public async Task<int> CreateRestaurant(object data)
		{
			CreateRestaurantJSONModel? model = JsonConvert.DeserializeObject<CreateRestaurantJSONModel>(data.ToString());

			if(model == null)
			{
				return -1;
			}

			int cityId = await this._cityService.GetCityIdByName(model.CityName);
			int ownerId = await this._restaurateurService.GetRestaurateurByUserId(model.OwnerId);

			Restaurant restaurant = new Restaurant() 
			{ 
				Name = model.Name,
				Description = model.Description,
				ImgLinkUrl = model.ImgLinkUrl,
				DeliveryTime = model.DeliveryTime,
				MinMoneyForOrder = model.MinMoneyForOrder,
				OwnerId = ownerId,
				CityId = cityId,
			};
			
			await this._context.Restaurants.AddAsync(restaurant);
			await this._context.SaveChangesAsync();

			return restaurant.Id;
		}

		public async Task<DetailsRestaurantModel> GetRestaurantById(int id)
		{
			DetailsRestaurantModel? restaurant = await this._context.Restaurants
				.Select(r => new DetailsRestaurantModel()
				{
					Id = r.Id,
					Name = r.Name,
					Description = r.Description,
					ImgLinkUrl = r.ImgLinkUrl,
					DeliveryTime = r.DeliveryTime,
					MinMoneyForOrder = r.MinMoneyForOrder,
					OwnerId = r.OwnerId,
					Products = r.Products
								.Where(p => p.RestaurantId == id)
								.Select(p => new ProductModel
								{
									Id = p.Id,
									Name = p.Name,
									Description = p.Description,
									Type = p.Type.ToString(),
									Price = p.Price,
									Weight = p.Weight,
								})
								.ToList()
				})
				.FirstOrDefaultAsync(r => r.Id == id);

			return restaurant;
		}
	}
}
