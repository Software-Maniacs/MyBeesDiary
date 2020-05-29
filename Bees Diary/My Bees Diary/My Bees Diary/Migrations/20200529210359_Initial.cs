using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBeesDiary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apiaries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Production = table.Column<decimal>(nullable: false),
                    Honey = table.Column<decimal>(nullable: false),
                    Wax = table.Column<decimal>(nullable: false),
                    Propolis = table.Column<decimal>(nullable: false),
                    Pollen = table.Column<decimal>(nullable: false),
                    RoyalJelly = table.Column<decimal>(nullable: false),
                    Poison = table.Column<decimal>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Summary = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Beehives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    TypeBeehive = table.Column<string>(nullable: true),
                    TypeBees = table.Column<string>(nullable: true),
                    Stores = table.Column<int>(nullable: false),
                    Power = table.Column<decimal>(nullable: false),
                    Feedings = table.Column<int>(nullable: false),
                    Reviews = table.Column<int>(nullable: false),
                    Treatments = table.Column<int>(nullable: false),
                    Production = table.Column<decimal>(nullable: false),
                    Honey = table.Column<decimal>(nullable: false),
                    Wax = table.Column<decimal>(nullable: false),
                    Propolis = table.Column<decimal>(nullable: false),
                    Pollen = table.Column<decimal>(nullable: false),
                    RoyalJelly = table.Column<decimal>(nullable: false),
                    Poison = table.Column<decimal>(nullable: false),
                    ApiaryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beehives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Beehives_Apiaries_ApiaryID",
                        column: x => x.ApiaryID,
                        principalTable: "Apiaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beehives_ApiaryID",
                table: "Beehives",
                column: "ApiaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beehives");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Apiaries");
        }
    }
}
