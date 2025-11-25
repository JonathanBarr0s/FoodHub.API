using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Restaurant;

namespace FoodHub.API.Services.Interfaces
{
	public interface IRestaurantService
	{
		Task<IEnumerable<RestaurantDto>> GetAllAsync();
		Task<RestaurantDto?> GetByIdAsync(int id);
		Task<RestaurantDto> AddAsync(RestaurantCreateDto dto);
		Task<bool> UpdateAsync(int id, RestaurantUpdateDto dto);
		Task<bool> DeleteAsync(int id);
	}
}
