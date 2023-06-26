namespace HappyMeal.Core.Initialize
{
    using HappyMeal.Core.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class InitializeDbContext
    {
        private User User { get; set; } = null!;

        private Admin Admin { get; set; } = null!;

        private Cart Cart { get; set; } = null!;

        public ModelBuilder SetUpEntitiesConnections(ModelBuilder builder)
        {
            builder
                .Entity<Addon>()
                .HasOne(a => a.Product)
                .WithMany(a => a.Addons)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(c => c.Cart)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Product>()
                .HasOne(p => p.Restaurant)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Restaurant>()
                .HasOne(r => r.Restaurateur)
                .WithMany(r => r.Restaurants)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Restaurant>()
                .HasOne(r => r.City)
                .WithMany(r => r.Restaurants)
                .HasForeignKey(r => r.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Restaurateur>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Review>()
                .HasOne(r => r.Restaurant)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<User>()
                .HasOne(r => r.Cart)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Restrict);

            return builder;
        }

        public ModelBuilder SetUpEntitiesData(ModelBuilder builder)
        {
            SeedData();

            builder
                .Entity<User>()
                .HasData(User);

            builder
                .Entity<Admin>()
                .HasData(Admin);

            builder
                .Entity<Cart>()
                .HasData(Cart);

            return builder;
        }

        private void SeedData()
        {
            User = new User()
            {
                Id = 1,
                FirstName = "Nikola",
                LastName = "Stefanov",
                PhoneNumber = "0895555123",
                Email = "nikola.stefanov@gmail.com",
                CartId = 1,
            };

            Admin = new Admin()
            {
                Id = 1,
                Name = "NikolaOwner",
                UserId = 1,
            };

            Cart = new Cart()
            {
                Id = 1,
                UserId = 1,
                DeliveryCosts = 0,
                Subtotal = 0
            };
        }
    }
}
