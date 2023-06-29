using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.Cart
{
	public interface ICartService
	{
		Task<int> GetLastCartId();

		Task CreateCart(int userId);
	}
}
