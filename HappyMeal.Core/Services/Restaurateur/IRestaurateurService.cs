using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.Restaurateur
{
	public interface IRestaurateurService
	{
		Task<bool> IsRestaurateur(int userId);

		Task Become(object auth);
	}
}
