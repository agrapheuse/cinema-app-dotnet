using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cinemaApp.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    country = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    city = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    director = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    category = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    fullName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.uuid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Showings",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    CinemaId = table.Column<Guid>(type: "char(36)", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    info_link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ticket_link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    MovieUuid = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showings", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Showings_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Showings_Movies_MovieUuid",
                        column: x => x.MovieUuid,
                        principalTable: "Movies",
                        principalColumn: "uuid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserCinema",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CinemaId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCinema", x => new { x.UserId, x.CinemaId });
                    table.ForeignKey(
                        name: "FK_UserCinema_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCinema_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    ShowingId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => new { x.UserId, x.ShowingId });
                    table.ForeignKey(
                        name: "FK_Likes_Showings_ShowingId",
                        column: x => x.ShowingId,
                        principalTable: "Showings",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "uuid", "city", "country", "name" },
                values: new object[,]
                {
                    { new Guid("8b659e03-0435-485b-8f77-9dff6e1f40e6"), "Antwerp", "Belgium", "Cartoon's" },
                    { new Guid("a6479f2a-963b-490f-ba92-6bdb99eb1f04"), "Antwerp", "Belgium", "Lumières" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Antwerp", "Belgium", "De Studio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ShowingId",
                table: "Likes",
                column: "ShowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_CinemaId",
                table: "Showings",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Showings_MovieUuid",
                table: "Showings",
                column: "MovieUuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserCinema_CinemaId",
                table: "UserCinema",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "UserCinema");

            migrationBuilder.DropTable(
                name: "Showings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
