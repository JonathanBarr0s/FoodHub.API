using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulateFoodHub_OrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				INSERT INTO ""FoodHub_OrderItem"" (""Quantity"", ""UnitPrice"", ""DishId"", ""OrderId"") VALUES
					(1, 35.90, 1, 1),
					(1, 29.90, 2, 2),
					(2, 52.00, 3, 3),
					(1, 89.00, 4, 4),
					(3, 18.50, 5, 5),
					(1, 22.00, 6, 6),
					(2, 6.00, 7, 7),
					(1, 32.00, 8, 8),
					(2, 27.00, 9, 9),
					(3, 14.00, 10, 10);"
			);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
