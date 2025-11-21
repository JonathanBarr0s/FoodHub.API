using System.ComponentModel.DataAnnotations.Schema;

namespace FoodHub.API.Entities
{
	[Table("FoodHub_User")]
	public class User
	{
		public int Id { get; set; }
		public string FullName { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		public List<Order> Orders { get; set; } = new();
	}
}