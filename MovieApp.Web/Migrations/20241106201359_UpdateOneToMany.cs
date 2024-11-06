using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Web.Migrations
{
    public partial class UpdateOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "genre_id",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "genre_id1",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genre_id1",
                table: "Movies",
                column: "genre_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genre_id1",
                table: "Movies",
                column: "genre_id1",
                principalTable: "Genres",
                principalColumn: "genre_id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genre_id1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genre_id1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genre_id1",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "genre_id",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
