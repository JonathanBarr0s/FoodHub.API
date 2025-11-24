namespace FoodHub.API.Dtos.Dish
{
	public class DishCreateDto
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public int RestaurantId { get; set; }
	}
}
