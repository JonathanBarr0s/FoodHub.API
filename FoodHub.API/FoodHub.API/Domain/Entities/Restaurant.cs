using FoodHub.API.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Domain.Entities
{
	[Table("FoodHub_Restaurant")]
	public class Restaurant : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
	
		public List<Dish> Dishes { get; set; } = new();
		public List<Order> Orders { get; set; } = new();
	}
}