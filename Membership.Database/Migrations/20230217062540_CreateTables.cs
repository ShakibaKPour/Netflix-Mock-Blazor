using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_ParentFilmId",
                table: "SimilarFilms");

            migrationBuilder.RenameColumn(
                name: "ParentFilmId",
                table: "SimilarFilms",
                newName: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarFilms_Films_FilmId",
                table: "SimilarFilms");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "SimilarFilms",
                newName: "ParentFilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarFilms_Films_ParentFilmId",
                table: "SimilarFilms",
                column: "ParentFilmId",
                principalTable: "Films",
                principalColumn: "Id");
        }
    }
}
