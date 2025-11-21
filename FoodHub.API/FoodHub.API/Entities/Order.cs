namespace FoodHub.API.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		
		public int UserId { get; set; }
		public User? User { get; set; }
		
		public int RestaurantId { get; set; }
		public Restaurant? Restaurant { get; set; }
		
		public List<OrderItem> Items { get; set; } = new();
		
		public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice);
	}
}