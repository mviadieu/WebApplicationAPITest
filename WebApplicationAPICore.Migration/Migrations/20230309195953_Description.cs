using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAPICore.Recipies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipie_Ingredient_IngredientId",
                table: "Recipie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipie",
                table: "Recipie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.RenameTable(
                name: "Recipie",
                newName: "Recipies");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameIndex(
                name: "IX_Recipie_IngredientId",
                table: "Recipies",
                newName: "IX_Recipies_IngredientId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recipies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipies",
                table: "Recipies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipies_Ingredients_IngredientId",
                table: "Recipies",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipies_Ingredients_IngredientId",
                table: "Recipies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipies",
                table: "Recipies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recipies");

            migrationBuilder.RenameTable(
                name: "Recipies",
                newName: "Recipie");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameIndex(
                name: "IX_Recipies_IngredientId",
                table: "Recipie",
                newName: "IX_Recipie_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipie",
                table: "Recipie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipie_Ingredient_IngredientId",
                table: "Recipie",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
