using FoodHub.API.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Domain.Entities
{
	[Table("FoodHub_OrderItem")]
	public class OrderItem : BaseEntity
	{
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
				
		public int DishId { get; set; }
		public Dish? Dish { get; set; }
		
		public int OrderId { get; set; }
		public Order? Order { get; set; }
	}
}