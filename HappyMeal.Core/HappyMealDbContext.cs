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

	}
}
