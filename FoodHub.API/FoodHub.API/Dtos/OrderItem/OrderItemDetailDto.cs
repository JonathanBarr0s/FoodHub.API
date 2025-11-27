using FoodHub.API.Dtos.Dish;

namespace FoodHub.API.Dtos.OrderItem
{
	public class OrderItemDetailDto
	{
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

		public DishDto Dish { get; set; }
	}

}
