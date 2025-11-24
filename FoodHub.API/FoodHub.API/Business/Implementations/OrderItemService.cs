using FoodHub.API.Business.Interfaces;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;

namespace FoodHub.API.Business.Implementations
{
	public class OrderItemService : Service<OrderItem>, IOrderItemService
	{
		public OrderItemService(IRepository<OrderItem> repository) : base(repository) { }
	}
}
