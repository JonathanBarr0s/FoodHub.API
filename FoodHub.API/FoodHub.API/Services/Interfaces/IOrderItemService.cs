using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.OrderItem;

namespace FoodHub.API.Services.Interfaces
{
	public interface IOrderItemService
	{
		Task<IEnumerable<OrderItemDto>> GetAllAsync();
		Task<OrderItemDto?> GetByIdAsync(int id);
		Task<OrderItemDto> AddAsync(OrderItemCreateDto dto);
		Task<bool> UpdateAsync(int id, OrderItemUpdateDto dto);
		Task<bool> DeleteAsync(int id);
	}
}
