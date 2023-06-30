using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMeal.Core.Services.Admin
{
	public interface IAdminService
	{
		Task<bool> IsAdmin(int userId);
	}
}
