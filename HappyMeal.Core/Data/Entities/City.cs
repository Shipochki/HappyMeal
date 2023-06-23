using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class City
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public HashSet<Restaurant> Restaurants { get; set; } = new HashSet<Restaurant>();
	}
}
