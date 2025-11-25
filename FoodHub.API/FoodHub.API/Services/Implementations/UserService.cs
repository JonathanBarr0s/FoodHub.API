using AutoMapper;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.User;
using FoodHub.API.Services.Interfaces;

namespace FoodHub.API.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _repository;
		private readonly IMapper _mapper;

		public UserService(IRepository<User> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<UserDto>> GetAllAsync()
		{
			var users = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<UserDto>>(users);
		}

		public async Task<UserDto?> GetByIdAsync(int id)
		{
			var user = await _repository.GetByIdAsync(id);
			if (user == null)
				return null;
			return _mapper.Map<UserDto>(user);
		}

		public async Task<UserDto> AddAsync(UserCreateDto dto)
		{
			var entity = _mapper.Map<User>(dto);
			await _repository.AddAsync(entity);
			await _repository.SaveChangesAsync();
			return _mapper.Map<UserDto>(entity);
		}

		public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
		{
			var user = await _repository.GetByIdAsync(id);
			if (user == null)
				return false;

			_mapper.Map(dto, user);
			_repository.Update(user);
			return await _repository.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var user = await _repository.GetByIdAsync(id);
			if (user == null)
				return false;

			_repository.Delete(user);
			return await _repository.SaveChangesAsync();
		}
	}
}