using HappyMeal.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core
{
	public class HappyMealDbContext : DbContext
	{
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
			builder.Entity<Addon>()
				.HasOne(a => a.Product)
				.WithMany(a => a.Addons)
				.HasForeignKey(a => a.ProductId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Admin>()
				.HasOne(a => a.User)
				.WithMany()
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Cart>()
				.HasOne(c => c.User)
				.WithOne(c => c.Cart)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Order>()
				.HasOne(o => o.User)
				.WithMany(o => o.Orders)
				.HasForeignKey(o => o.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Order>()
				.HasOne(o => o.Restaurant)
				.WithMany(o => o.Orders)
				.HasForeignKey(o => o.RestaurantId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Product>()
				.HasOne(p => p.Restaurant)
				.WithMany(p => p.Products)
				.HasForeignKey(p => p.RestaurantId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Restaurant>()
				.HasOne(r => r.Restaurateur)
				.WithMany(r => r.Restaurants)
				.HasForeignKey(r => r.OwnerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Restaurant>()
				.HasOne(r => r.City)
				.WithMany(r => r.Restaurants)
				.HasForeignKey(r => r.CityId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Restaurateur>()
				.HasOne(r => r.User)
				.WithMany()
				.HasForeignKey(r => r.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Review>()
				.HasOne(r => r.User)
				.WithMany(r => r.Reviews)
				.HasForeignKey(r => r.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Review>()
				.HasOne(r => r.Restaurant)
				.WithMany(r => r.Reviews)
				.HasForeignKey(r => r.RestaurantId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<User>()
				.HasOne(r => r.Cart)
				.WithOne(r => r.User)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);
		}
	}
}
