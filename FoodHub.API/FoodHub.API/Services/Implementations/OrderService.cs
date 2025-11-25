using AutoMapper;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Order;
using FoodHub.API.Services.Interfaces;

namespace FoodHub.API.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<Order> _repository;
		private readonly IMapper _mapper;

		public OrderService(IRepository<Order> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<OrderDto>> GetAllAsync()
		{
			var orders = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<OrderDto>>(orders);
		}

		public async Task<OrderDto?> GetByIdAsync(int id)
		{
			var order = await _repository.GetByIdAsync(id);
			if (order == null)
				return null;

			return _mapper.Map<OrderDto>(order);
		}

		public async Task<OrderDto> AddAsync(OrderCreateDto dto)
		{
			var order = _mapper.Map<Order>(dto);
			await _repository.AddAsync(order);
			await _repository.SaveChangesAsync();

			return _mapper.Map<OrderDto>(order);
		}

		public async Task<bool> UpdateAsync(int id, OrderUpdateDto dto)
		{
			var order = await _repository.GetByIdAsync(id);
			if (order == null)
				return false;

			_mapper.Map(dto, order);
			_repository.Update(order);

			return await _repository.SaveChangesAsync();
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var order = await _repository.GetByIdAsync(id);
			if (order == null)
				return false;

			_repository.Delete(order);

			return await _repository.SaveChangesAsync();
		}
	}
}
