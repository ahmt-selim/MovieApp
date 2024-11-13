using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Web.Migrations
{
    public partial class ManyToManyRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genre_id1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genre_id1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genre_id",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genre_id1",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    Genresgenre_id = table.Column<int>(type: "int", nullable: false),
                    Moviesmovie_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.Genresgenre_id, x.Moviesmovie_id });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_Genresgenre_id",
                        column: x => x.Genresgenre_id,
                        principalTable: "Genres",
                        principalColumn: "genre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_Movies_Moviesmovie_id",
                        column: x => x.Moviesmovie_id,
                        principalTable: "Movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_Moviesmovie_id",
                table: "GenreMovie",
                column: "Moviesmovie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.AddColumn<int>(
                name: "genre_id",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "genre_id1",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
