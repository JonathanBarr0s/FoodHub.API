using AutoMapper;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.OrderItem;
using FoodHub.API.Services.Interfaces;

namespace FoodHub.API.Services.Implementations
{
	public class OrderItemService : IOrderItemService
	{
		private readonly IRepository<OrderItem> _repository;
		private readonly IMapper _mapper;

		public OrderItemService(IRepository<OrderItem> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
		{
			var items = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<OrderItemDto>>(items);
		}

		public async Task<OrderItemDto?> GetByIdAsync(int id)
		{
			var item = await _repository.GetByIdAsync(id);
			if (item == null)
				return null;

			return _mapper.Map<OrderItemDto>(item);
		}

		public async Task<OrderItemDto> AddAsync(OrderItemCreateDto dto)
		{
			var entity = _mapper.Map<OrderItem>(dto);
			await _repository.AddAsync(entity);
			await _repository.SaveChangesAsync();

			return _mapper.Map<OrderItemDto>(entity);
		}

		public async Task<bool> UpdateAsync(int id, OrderItemUpdateDto dto)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
				return false;

			_mapper.Map(dto, entity);
			_repository.Update(entity);

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
