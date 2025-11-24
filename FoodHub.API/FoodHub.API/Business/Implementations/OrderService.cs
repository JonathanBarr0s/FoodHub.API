using FoodHub.API.Business.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Business.Implementations
{
	public class OrderService : Service<Order>, IOrderService
	{
		public OrderService(IRepository<Order> repository) : base(repository) { }
	}
}
