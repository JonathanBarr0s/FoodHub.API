using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Entities
{
	[Table("FoodHub_OrderItem")]
	public class OrderItem
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
				
		public int DishId { get; set; }
		public Dish? Dish { get; set; }
		
		public int OrderId { get; set; }
		public Order? Order { get; set; }
	}
}