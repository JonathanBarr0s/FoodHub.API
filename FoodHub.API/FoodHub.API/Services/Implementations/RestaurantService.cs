using AutoMapper;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Restaurant;
using FoodHub.API.Services.Interfaces;

namespace FoodHub.API.Services.Implementations
{
	public class RestaurantService : IRestaurantService
	{
		private readonly IRepository<Restaurant> _repository;
		private readonly IMapper _mapper;

		public RestaurantService(
			IRepository<Restaurant> repository,
			IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RestaurantDto>> GetAllAsync()
		{
			var restaurants = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
		}

		public async Task<RestaurantDto?> GetByIdAsync(int id)
		{
			var restaurant = await _repository.GetByIdAsync(id);
			if (restaurant == null)
				return null;

			return _mapper.Map<RestaurantDto>(restaurant);
		}

		public async Task<RestaurantDto> AddAsync(RestaurantCreateDto dto)
		{
			var entity = _mapper.Map<Restaurant>(dto);

			await _repository.AddAsync(entity);
			await _repository.SaveChangesAsync();

			return _mapper.Map<RestaurantDto>(entity);
		}

		public async Task<bool> UpdateAsync(int id, RestaurantUpdateDto dto)
		{
			var restaurant = await _repository.GetByIdAsync(id);
			if (restaurant == null)
				return false;

			_mapper.Map(dto, restaurant);

			_repository.Update(restaurant);
			return await _repository.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var restaurant = await _repository.GetByIdAsync(id);
			if (restaurant == null)
				return false;

			_repository.Delete(restaurant);
			return await _repository.SaveChangesAsync();
		}
	}
}
