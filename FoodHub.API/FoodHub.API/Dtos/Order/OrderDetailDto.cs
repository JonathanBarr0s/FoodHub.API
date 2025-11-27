using FoodHub.API.Dtos.OrderItem;
using FoodHub.API.Dtos.Restaurant;
using FoodHub.API.Dtos.User;

namespace FoodHub.API.Dtos.Order
{
	public class OrderDetailDto
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public decimal Total { get; set; }

		public UserDto User { get; set; }
		public RestaurantDto Restaurant { get; set; }

		public List<OrderItemDetailDto> Items { get; set; } = new();
	}
}