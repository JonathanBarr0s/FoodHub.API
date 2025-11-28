using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Order;

namespace FoodHub.API.Services.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderDetailDto>> GetAllAsync();
		Task<OrderDetailDto?> GetByIdAsync(int id);
		Task<OrderDetailDto> CreateAsync(OrderCreateDto dto);
		Task<OrderDetailDto> AddItemAsync(OrderAddItemDto dto);
		Task<bool> DeleteAsync(int id);
	}
}
