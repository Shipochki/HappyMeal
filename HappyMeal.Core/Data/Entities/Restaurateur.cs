using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Data.Entities
{
	public class Restaurateur
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public HashSet<Restaurant> Restaurants { get; set;} = new HashSet<Restaurant>();
	}
}
