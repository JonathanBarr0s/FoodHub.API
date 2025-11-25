using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Order;

namespace FoodHub.API.Services.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderDto>> GetAllAsync();
		Task<OrderDto?> GetByIdAsync(int id);
		Task<OrderDto> AddAsync(OrderCreateDto dto);
		Task<bool> UpdateAsync(int id, OrderUpdateDto dto);
		Task<bool> DeleteAsync(int id);
	}
}
