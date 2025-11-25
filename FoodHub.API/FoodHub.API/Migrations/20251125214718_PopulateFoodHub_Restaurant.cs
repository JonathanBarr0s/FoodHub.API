using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.API.Migrations
{
	/// <inheritdoc />
	public partial class PopulateFoodHub_Restaurant : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				INSERT INTO ""FoodHub_Restaurant"" (""Name"", ""Address"") VALUES
					('Pizzaria Sabor', 'Rua A, 123'),
					('Hamburgueria Top', 'Rua B, 456'),
					('Sushi Master', 'Rua C, 789'),
					('Churrascaria Fogo', 'Avenida Central, 100'),
					('Taco Loco', 'Rua México, 22'),
					('Vegan Life', 'Alameda Verde, 55'),
					('Café Brasil', 'Rua das Flores, 8'),
					('Massas Itália', 'Rua Roma, 12'),
					('Chicken House', 'Rua do Frango, 77'),
					('Panquecas da Vovó', 'Travessa 3, 9');"
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
