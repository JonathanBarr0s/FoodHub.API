using FoodHub.API.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Domain.Entities
{
	[Table("FoodHub_Dish")]
	public class Dish : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public decimal Price { get; set; }
		
		public int RestaurantId { get; set; }
		public Restaurant? Restaurant { get; set; }
	}
}