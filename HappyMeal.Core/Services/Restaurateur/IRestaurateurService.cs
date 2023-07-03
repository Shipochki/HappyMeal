using HappyMeal.Core.Services.Restaurateur.Models;

namespace HappyMeal.Core.Services.Restaurateur
{
	public interface IRestaurateurService
	{
		Task<bool> IsRestaurateur(int userId);

		Task Become(object auth);

		Task<List<RestaurateurModel>> GetAllCandidates();

		Task<bool> IsCandidate(int userId);
	}
}
