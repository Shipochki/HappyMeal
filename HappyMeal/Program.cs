using HappyMeal.Core;
using HappyMeal.Core.Services.Cart;
using HappyMeal.Core.Services.City;
using HappyMeal.Core.Services.Restaurant;
using HappyMeal.Core.Services.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HappyMealDbContext>(options => 
	options.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseRouting();

app.MapControllers();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action}");

app.MapFallbackToFile("index.html"); ;

app.Run();
