using FoodHub.API.Dtos.Dish;
using FoodHub.API.Dtos.Order;

namespace FoodHub.API.Dtos.OrderItem
{
	public class OrderItemDetailDto
	{
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		public OrderDishDto Dish { get; set; }
	}
}