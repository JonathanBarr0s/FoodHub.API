using FoodHub.API.Business.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Business.Implementations
{
	public class DishService : Service<Dish>, IDishService
	{
		public DishService(IRepository<Dish> repository) : base(repository) { }
	}
}
