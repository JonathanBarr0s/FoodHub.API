using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulateFoodHub_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				INSERT INTO ""FoodHub_Order"" (""CreatedAt"", ""UserId"", ""RestaurantId"") VALUES
					('2025-11-25 15:30:00', 1, 1),
					('2025-11-24 10:45:00', 2, 2),
					('2025-11-20 20:00:00', 3, 3),
					('2025-11-15 18:15:00', 4, 4),
					('2025-11-01 12:00:00', 5, 5),
					('2025-10-25 09:00:00', 6, 6),
					('2025-10-01 14:00:00', 7, 7),
					('2025-09-15 17:30:00', 8, 8),
					('2025-09-01 22:00:00', 9, 9),
					('2025-08-10 11:00:00', 10, 10);"
			);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
