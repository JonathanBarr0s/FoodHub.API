using AutoMapper;
using FoodHub.API.Domain.Entities;
using FoodHub.API.Dtos.Dish;
using FoodHub.API.Dtos.Order;
using FoodHub.API.Dtos.OrderItem;
using FoodHub.API.Dtos.Restaurant;
using FoodHub.API.Dtos.User;

namespace FoodHub.API.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			// Restaurant
			CreateMap<Restaurant, RestaurantDto>();
			CreateMap<RestaurantCreateDto, Restaurant>();
			CreateMap<RestaurantUpdateDto, Restaurant>();

			// Dish
			CreateMap<Dish, DishDto>();
			CreateMap<DishCreateDto, Dish>();
			CreateMap<DishUpdateDto, Dish>();

			// User
			CreateMap<User, UserDto>();
			CreateMap<UserCreateDto, User>();
			CreateMap<UserUpdateDto, User>();

			// Order
			CreateMap<Order, OrderDto>();
			CreateMap<Order, OrderDetailDto>();

			// OrderItem
			CreateMap<OrderItem, OrderItemDto>();
			CreateMap<OrderItem, OrderItemDetailDto>();
		}
	}
}