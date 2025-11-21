using FoodHub.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}