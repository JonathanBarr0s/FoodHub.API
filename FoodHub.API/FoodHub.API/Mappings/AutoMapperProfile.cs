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
			CreateMap<Restaurant, RestaurantDto>();
			CreateMap<RestaurantCreateDto, Restaurant>();
			CreateMap<RestaurantUpdateDto, Restaurant>();

			CreateMap<Dish, DishDto>();
			CreateMap<DishCreateDto, Dish>();
			CreateMap<DishUpdateDto, Dish>();

			CreateMap<User, UserDto>();
			CreateMap<UserCreateDto, User>();
			CreateMap<UserUpdateDto, User>();

			CreateMap<Order, OrderDetailDto>();

			CreateMap<OrderItem, OrderItemDetailDto>();

			CreateMap<OrderCreateDto, Order>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
				.ForMember(dest => dest.Items, opt => opt.Ignore()); 

			CreateMap<OrderAddItemDto, OrderItem>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.OrderId, opt => opt.Ignore())     
				.ForMember(dest => dest.UnitPrice, opt => opt.Ignore());  
		}
	}
}