using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Migrations
{
    /// <inheritdoc />
    public partial class SecondFixedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngrediants_Ingrediants_DishId",
                table: "DishIngrediants");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngrediants_IngrediantId",
                table: "DishIngrediants",
                column: "IngrediantId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngrediants_Ingrediants_IngrediantId",
                table: "DishIngrediants",
                column: "IngrediantId",
                principalTable: "Ingrediants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngrediants_Ingrediants_IngrediantId",
                table: "DishIngrediants");

            migrationBuilder.DropIndex(
                name: "IX_DishIngrediants_IngrediantId",
                table: "DishIngrediants");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngrediants_Ingrediants_DishId",
                table: "DishIngrediants",
                column: "DishId",
                principalTable: "Ingrediants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
