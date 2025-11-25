using FoodHub.API.Services.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Services.Implementations
{
	public class DishService : Service<Dish>, IDishService
	{
		public DishService(IRepository<Dish> repository) : base(repository) { }
	}
}
