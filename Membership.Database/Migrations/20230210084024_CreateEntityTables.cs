﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateEntityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Released = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    Free = table.Column<bool>(type: "bit", nullable: false),
                    FilmUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SimilarFilms",
                columns: table => new
                {
                    ParentFilmId = table.Column<int>(type: "int", nullable: false),
                    SimilarFilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarFilms", x => new { x.ParentFilmId, x.SimilarFilmId });
                    table.ForeignKey(
                        name: "FK_SimilarFilms_Films_ParentFilmId",
                        column: x => x.ParentFilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SimilarFilms_Films_SimilarFilmId",
                        column: x => x.SimilarFilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenreId",
                table: "FilmGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarFilms_SimilarFilmId",
                table: "SimilarFilms",
                column: "SimilarFilmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "SimilarFilms");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Directors");
        }
    }
}
