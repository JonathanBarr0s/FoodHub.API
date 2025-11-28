namespace FoodHub.API.Dtos.Order
{
	public class OrderCreateDto
	{
		public int UserId { get; set; }
		public int RestaurantId { get; set; }
		public int DishId { get; set; }
		public int Quantity { get; set; }
	}
}