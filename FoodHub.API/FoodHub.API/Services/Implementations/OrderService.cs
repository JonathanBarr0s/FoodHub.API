using FoodHub.API.Services.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Services.Implementations
{
	public class OrderService : Service<Order>, IOrderService
	{
		public OrderService(IRepository<Order> repository) : base(repository) { }
	}
}
