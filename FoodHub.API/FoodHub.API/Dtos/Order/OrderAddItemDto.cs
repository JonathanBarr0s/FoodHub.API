using System.Text.Json.Serialization;

namespace FoodHub.API.Dtos.Order
{
	public class OrderAddItemDto
	{
		[JsonIgnore]
		public int OrderId { get; set; }

		public int DishId { get; set; }
		public int Quantity { get; set; }
	}
}
