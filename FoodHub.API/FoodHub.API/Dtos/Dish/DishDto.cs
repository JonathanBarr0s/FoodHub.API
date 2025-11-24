namespace FoodHub.API.Dtos.Dish
{
	public class DishDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int RestaurantId { get; set; }
	}
}
