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

		}

		public DbSet<Addon> Addons { get; set; }

		public DbSet<Admin> Admins { get; set; }

		public DbSet<Cart> Carts { get; set; }

		public DbSet<CartProduct> CartsProducts { get; set; }
	}
}
