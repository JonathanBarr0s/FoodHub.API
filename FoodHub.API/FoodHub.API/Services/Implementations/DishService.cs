using AutoMapper;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Dish;
using FoodHub.API.Services.Interfaces;

namespace FoodHub.API.Services.Implementations
{
	public class DishService : IDishService
	{
		private readonly IRepository<Dish> _repository;
		private readonly IMapper _mapper;

		public DishService(
			IRepository<Dish> repository,
			IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<DishDto>> GetAllAsync()
		{
			var dishes = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<DishDto>>(dishes);
		}

		public async Task<DishDto?> GetByIdAsync(int id)
		{
			var dish = await _repository.GetByIdAsync(id);
			if (dish == null)
				return null;

			return _mapper.Map<DishDto>(dish);
		}

		public async Task<DishDto> AddAsync(DishCreateDto dto)
		{
			var entity = _mapper.Map<Dish>(dto);

			await _repository.AddAsync(entity);
			await _repository.SaveChangesAsync();

			return _mapper.Map<DishDto>(entity);
		}

		public async Task<bool> UpdateAsync(int id, DishUpdateDto dto)
		{
			var dish = await _repository.GetByIdAsync(id);
			if (dish == null)
				return false;

			_mapper.Map(dto, dish);

			_repository.Update(dish);
			return await _repository.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
				return false;

			_repository.Delete(entity);
			return await _repository.SaveChangesAsync();
		}
	}
}
