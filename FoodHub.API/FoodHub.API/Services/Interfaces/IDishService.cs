using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Dish;

namespace FoodHub.API.Services.Interfaces
{
	public interface IDishService
	{
		Task<IEnumerable<DishDto>> GetAllAsync();
		Task<DishDto?> GetByIdAsync(int id);
		Task<DishDto> AddAsync(DishCreateDto dto);
		Task<bool> UpdateAsync(int id, DishUpdateDto dto);
		Task<bool> DeleteAsync(int id);
	}
}