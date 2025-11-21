using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Entities
{
	[Table("FoodHub_Dish")]
	public class Dish
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		
		public int RestaurantId { get; set; }
		public Restaurant? Restaurant { get; set; }
	}
}