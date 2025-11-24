using FoodHub.API.Business.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Business.Implementations
{
	public class RestaurantService : Service<Restaurant>, IRestaurantService
	{
		public RestaurantService(IRepository<Restaurant> repository) : base(repository) { }
	}
}
