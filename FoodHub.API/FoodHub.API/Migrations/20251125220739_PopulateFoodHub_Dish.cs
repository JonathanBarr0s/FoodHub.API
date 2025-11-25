using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.API.Migrations
{
    /// <inheritdoc />
    public partial class PopulateFoodHub_Dish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
				INSERT INTO ""FoodHub_Dish"" (""Name"", ""Price"", ""RestaurantId"") VALUES
					('Pizza Margherita', 35.90, 1),
					('Hamburguer Artesanal', 29.90, 2),
					('Sushi Combo', 52.00, 3),
					('Picanha Grill', 89.00, 4),
					('Taco Especial', 18.50, 5),
					('Salada Vegana', 22.00, 6),
					('Café Expresso', 6.00, 7),
					('Lasanha Bolonhesa', 32.00, 8),
					('Frango Frito', 27.00, 9),
					('Panqueca Doce', 14.00, 10);"
			);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
