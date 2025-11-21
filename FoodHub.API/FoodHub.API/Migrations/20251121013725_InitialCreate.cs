using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodHub.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodHub_Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHub_Restaurant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodHub_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHub_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodHub_Dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
					Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
					RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHub_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodHub_Dish_FoodHub_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "FoodHub_Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodHub_Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHub_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodHub_Order_FoodHub_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "FoodHub_Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodHub_Order_FoodHub_User_UserId",
                        column: x => x.UserId,
                        principalTable: "FoodHub_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodHub_OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodHub_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodHub_OrderItem_FoodHub_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "FoodHub_Dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodHub_OrderItem_FoodHub_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "FoodHub_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodHub_Dish_RestaurantId",
                table: "FoodHub_Dish",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHub_Order_RestaurantId",
                table: "FoodHub_Order",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHub_Order_UserId",
                table: "FoodHub_Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHub_OrderItem_DishId",
                table: "FoodHub_OrderItem",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodHub_OrderItem_OrderId",
                table: "FoodHub_OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodHub_OrderItem");

            migrationBuilder.DropTable(
                name: "FoodHub_Dish");

            migrationBuilder.DropTable(
                name: "FoodHub_Order");

            migrationBuilder.DropTable(
                name: "FoodHub_Restaurant");

            migrationBuilder.DropTable(
                name: "FoodHub_User");
        }
    }
}
