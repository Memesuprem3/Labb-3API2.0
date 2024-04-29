using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3API2._0.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_PersonInterestId",
                        column: x => x.PersonInterestId,
                        principalTable: "PersonInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Konsten att fånga ögonblick.", "Fotografering" },
                    { 2, "Utmaningen att nå toppen.", "Bergsklättring" },
                    { 3, "CRUD4LIFE.", "Programering" },
                    { 4, "Utmaningen att hoppa med hästt.", "Ridning" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna Svensson", "0701234567" },
                    { 2, "Johan Karlsson", "0722345678" },
                    { 3, "Christian Rapp", "0722345678" },
                    { 4, "Fredrik Rapp", "0721344677" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "PersonInterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "http://example.com/foto" },
                    { 2, 2, "http://example.com/bergsbestigning" },
                    { 3, 3, "http://example.com/Microsoft" },
                    { 4, 4, "http://example.com/Ridsport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestId",
                table: "Links",
                column: "PersonInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
