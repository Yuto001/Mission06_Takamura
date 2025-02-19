using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission06_Takamura.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmInfos",
                table: "FilmInfos");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "FilmInfos");

            migrationBuilder.RenameTable(
                name: "FilmInfos",
                newName: "Movies");

            migrationBuilder.RenameColumn(
                name: "Lent",
                table: "Movies",
                newName: "LentTo");

            migrationBuilder.RenameColumn(
                name: "FilmID",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CopiedToPlex",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Category_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Category_CategoryId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CopiedToPlex",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "FilmInfos");

            migrationBuilder.RenameColumn(
                name: "LentTo",
                table: "FilmInfos",
                newName: "Lent");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "FilmInfos",
                newName: "FilmID");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "FilmInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmInfos",
                table: "FilmInfos",
                column: "FilmID");
        }
    }
}
