namespace HappyMeal.Core
{
    using HappyMeal.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using HappyMeal.Core.Initialize;

    public class HappyMealDbContext : DbContext
	{
		private InitializeDbContext _initialize = new InitializeDbContext();

		public HappyMealDbContext(DbContextOptions<HappyMealDbContext> options)
			:base(options)
		{
			if (this.Database.IsRelational())
			{
				this.Database.Migrate();
			}
			else
			{
				this.Database.EnsureCreated();
			}
		}

		public DbSet<Addon> Addons { get; set; } = null!;

		public DbSet<Admin> Admins { get; set; } = null!;

		public DbSet<Cart> Carts { get; set; } = null!; 

		public DbSet<CartProduct> CartsProducts { get; set; } = null!;

		public DbSet<City> Cities { get; set; } = null!;

		public DbSet<Order> Orders { get; set; } = null!;

		public DbSet<OrderProduct> OrderedProducts { get; set; } = null!;

		public DbSet<Product> Products { get; set; } = null!;

		public DbSet<Restaurant> Restaurants { get; set; } = null!;

		public DbSet<Restaurateur> Restaurateurs { get; set; } = null!;

		public DbSet<Review> Reviews { get; set; } = null!;

		public DbSet<User> Users { get; set; } = null!; 


		protected override void OnModelCreating(ModelBuilder builder)
		{
			_initialize.SetUpEntitiesConnections(builder);

			_initialize.SetUpEntitiesData(builder);

			base.OnModelCreating(builder);
		}
	}
}
