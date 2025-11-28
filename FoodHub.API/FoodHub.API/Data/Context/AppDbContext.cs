using FoodHub.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.API.Data.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
		{
		}

		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Dish> Dishes { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Order)
				.WithMany(o => o.Items)
				.HasForeignKey(oi => oi.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Dish)
				.WithMany()
				.HasForeignKey(oi => oi.DishId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}