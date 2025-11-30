using AutoMapper;
using FoodHub.API.Data.Repository.Interfaces;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Order;
using FoodHub.API.Dtos.OrderItem;
using FoodHub.API.Dtos.Restaurant;
using FoodHub.API.Dtos.User;
using FoodHub.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.API.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IRepository<Order> _repository;
		private readonly IRepository<OrderItem> _orderItemRepository;
		private readonly IRepository<Restaurant> _restaurantRepository;
		private readonly IRepository<Dish> _dishRepository;
		private readonly IRepository<User> _userRepository;
		private readonly IMapper _mapper;

		public OrderService(
			IRepository<Order> repository,
			IRepository<OrderItem> orderItemRepository,
			IRepository<Restaurant> restaurantRepository,
		IRepository<Dish> dishRepository,
			IRepository<User> userRepository,
			IMapper mapper)
		{
			_repository = repository;
			_orderItemRepository = orderItemRepository;
			_restaurantRepository = restaurantRepository;
			_dishRepository = dishRepository;
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<OrderDetailDto>> GetAllAsync()
		{
			var orders = await _repository.Query()
				.Include(o => o.User)
				.Include(o => o.Restaurant)
				.Include(o => o.Items)
					.ThenInclude(i => i.Dish)
				.ToListAsync();

			return orders.Select(MapOrder);
		}

		public async Task<OrderDetailDto?> GetByIdAsync(int id)
		{
			var order = await _repository.Query()
				.Include(o => o.User)
				.Include(o => o.Restaurant)
				.Include(o => o.Items)
					.ThenInclude(i => i.Dish)
				.FirstOrDefaultAsync(o => o.Id == id);

			return order == null ? null : MapOrder(order);
		}

		public async Task<OrderDetailDto> CreateAsync(OrderCreateDto dto)
		{
			if (dto == null)
				throw new ArgumentNullException(nameof(dto));

			if (dto.Quantity <= 0)
				throw new InvalidOperationException("Quantity must be greater than zero.");

			var user = await _userRepository.GetByIdAsync(dto.UserId)
				?? throw new InvalidOperationException("User not found.");

			var restaurant = await _restaurantRepository.GetByIdAsync(dto.RestaurantId)
				?? throw new InvalidOperationException("Restaurant not found.");

			var dish = await _dishRepository.GetByIdAsync(dto.DishId)
				?? throw new InvalidOperationException("Dish not found.");

			if (dish.RestaurantId != dto.RestaurantId)
				throw new InvalidOperationException("Dish does not belong to the informed restaurant.");

			var order = new Order
			{
				UserId = dto.UserId,
				RestaurantId = dto.RestaurantId,
				Items = new List<OrderItem>()
			};

			order.Items.Add(new OrderItem
			{
				DishId = dto.DishId,
				Quantity = dto.Quantity,
				UnitPrice = dish.Price
			});

			await _repository.AddAsync(order);
			await _repository.SaveChangesAsync();

			var detailed = await _repository.Query()
				.Include(o => o.User)
				.Include(o => o.Restaurant)
				.Include(o => o.Items)
					.ThenInclude(i => i.Dish)
				.FirstAsync(o => o.Id == order.Id);

			return MapOrder(detailed);
		}

		public async Task<OrderDetailDto> AddItemAsync(OrderAddItemDto dto)
		{
			if (dto == null)
				throw new ArgumentNullException(nameof(dto));
			if (dto.Quantity <= 0)
				throw new InvalidOperationException("Quantity must be greater than zero.");

			var order = await _repository.Query()
				.Include(o => o.Items)
				.FirstOrDefaultAsync(o => o.Id == dto.OrderId)
				?? throw new InvalidOperationException("Order not found.");

			var dish = await _dishRepository.GetByIdAsync(dto.DishId)
				?? throw new InvalidOperationException("Dish not found.");

			if (dish.RestaurantId != order.RestaurantId)
				throw new InvalidOperationException("Dish does not belong to the restaurant of the order.");

			var item = new OrderItem
			{
				OrderId = order.Id,
				DishId = dto.DishId,
				Quantity = dto.Quantity,
				UnitPrice = dish.Price
			};

			await _orderItemRepository.AddAsync(item);
			await _repository.SaveChangesAsync();

			var detailed = await _repository.Query()
				.Include(o => o.User)
				.Include(o => o.Restaurant)
				.Include(o => o.Items)
					.ThenInclude(i => i.Dish)
				.FirstAsync(o => o.Id == order.Id);

			return MapOrder(detailed);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var order = await _repository.GetByIdAsync(id);
			if (order == null)
				return false;

			_repository.Delete(order);
			return await _repository.SaveChangesAsync();
		}

		private OrderDetailDto MapOrder(Order order)
		{
			return new OrderDetailDto
			{
				Id = order.Id,
				CreatedAt = order.CreatedAt,
				Total = order.Items.Sum(i => i.UnitPrice * i.Quantity),

				User = _mapper.Map<UserDto>(order.User),
				Restaurant = _mapper.Map<RestaurantDto>(order.Restaurant),

				Items = order.Items.Select(i => new OrderItemDetailDto
				{
					Quantity = i.Quantity,
					UnitPrice = i.UnitPrice,
					Dish = new OrderDishDto
					{
						Id = i.Dish.Id,
						Name = i.Dish.Name
					}
				}).ToList()
			};
		}
	}
}