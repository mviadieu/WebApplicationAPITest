using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAPICore.Recipies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Picture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Recipie",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipie",
                table: "Recipie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipie_PictureId",
                table: "Recipie",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipie_Ingredient_IngredientId",
                table: "Recipie",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipie_Pictures_PictureId",
                table: "Recipie",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipie_Ingredient_IngredientId",
                table: "Recipie");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipie_Pictures_PictureId",
                table: "Recipie");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipie",
                table: "Recipie");

            migrationBuilder.DropIndex(
                name: "IX_Recipie_PictureId",
                table: "Recipie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Recipie");

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
    }
}
