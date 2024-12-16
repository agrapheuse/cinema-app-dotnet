using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                name: "Cinema",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    country = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    city = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.uuid);
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
                name: "Movies",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    director = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    category = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "longtext", nullable: true),
                    CinemaId = table.Column<Guid>(type: "char(36)", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    image_url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    info_link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ticket_link = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Movies_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "uuid",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    uuid = table.Column<Guid>(type: "char(36)", nullable: false),
                    MovieId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_Likes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
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

            migrationBuilder.CreateIndex(
                name: "IX_Likes_MovieId",
                table: "Likes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CinemaId",
                table: "Movies",
                column: "CinemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
