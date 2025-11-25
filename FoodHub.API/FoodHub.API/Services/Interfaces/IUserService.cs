using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.User;

namespace FoodHub.API.Services.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserDto>> GetAllAsync();
		Task<UserDto?> GetByIdAsync(int id);
		Task<UserDto> AddAsync(UserCreateDto dto);
		Task<bool> UpdateAsync(int id, UserUpdateDto dto);
		Task<bool> DeleteAsync(int id);
	}
}