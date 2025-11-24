namespace FoodHub.API.Dtos.Order
{
	public class OrderDto
	{
		public int Id { get; set; }
		public int RestaurantId { get; set; }
		public int UserId { get; set; }
		public decimal Total { get; set; }
	}
}
