using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.API.Migrations
{
	/// <inheritdoc />
	public partial class PopulateFoodHub_User : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				INSERT INTO ""FoodHub_User"" (""FullName"", ""Email"", ""Password"") VALUES
					('João Silva','joao@example.com', 'senha123'),
					('Maria Souza','maria@example.com', 'maria456'),
					('Pedro Santos','pedro@example.com', 'pedro789'),
					('Ana Lima','ana@example.com', 'lima123'),
					('Lucas Rocha','lucas@example.com', 'rocha456'),
					('Carla Mendes','carla@example.com', 'mendes789'),
					('Rafael Dias','rafael@example.com', 'dias123'),
					('Julia Alves','julia@example.com', 'alves456'),
					('Marcelo Ramos','marcelo@example.com', 'ramos789'),
					('Fernanda Costa','fernanda@example.com', 'costa123');"
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
