using FoodHub.API.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Domain.Entities
{
	[Table("FoodHub_User")]
	public class User : BaseEntity
	{
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		public List<Order> Orders { get; set; } = new();
	}
}