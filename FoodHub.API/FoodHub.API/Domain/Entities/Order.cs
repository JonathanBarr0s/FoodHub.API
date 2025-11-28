using FoodHub.API.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Domain.Entities
{
	[Table("FoodHub_Order")]
	public class Order : BaseEntity
	{
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public int UserId { get; set; }
		public User? User { get; set; }

		public int RestaurantId { get; set; }
		public Restaurant? Restaurant { get; set; }

		public List<OrderItem> Items { get; set; } = new();

		[NotMapped]
		public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice);
	}
}