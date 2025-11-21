namespace FoodHub.API.Entities
{
	public class Restaurant
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
	
		public List<Dish> Dishes { get; set; } = new();
		public List<Order> Orders { get; set; } = new();
	}
}