using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodHub.API.Migrations
{
    /// <inheritdoc />
    public partial class NewAdjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodHub_OrderItem_FoodHub_Dish_DishId",
                table: "FoodHub_OrderItem");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodHub_OrderItem_FoodHub_Dish_DishId",
                table: "FoodHub_OrderItem",
                column: "DishId",
                principalTable: "FoodHub_Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodHub_OrderItem_FoodHub_Dish_DishId",
                table: "FoodHub_OrderItem");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodHub_OrderItem_FoodHub_Dish_DishId",
                table: "FoodHub_OrderItem",
                column: "DishId",
                principalTable: "FoodHub_Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
