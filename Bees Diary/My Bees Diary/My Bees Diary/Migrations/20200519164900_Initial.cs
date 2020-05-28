using Microsoft.EntityFrameworkCore.Migrations;
using My_Bees_Diary.Models.Entities;

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
                    Type = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    Production = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    AreaPlants = table.Column<AreaPlants>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apiaries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AreaPlants",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    ApiaryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPlants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AreaPlants_Apiaries_ApiaryID",
                        column: x => x.ApiaryID,
                        principalTable: "Apiaries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beehives",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: false),
                    TypeBeehive = table.Column<string>(nullable: true),
                    TypeBees = table.Column<string>(nullable: true),
                    Stores = table.Column<int>(nullable: false),
                    Production = table.Column<decimal>(nullable: false),
                    Power = table.Column<decimal>(nullable: false),
                    Feedings = table.Column<int>(nullable: false),
                    Reviews = table.Column<int>(nullable: false),
                    Treatments = table.Column<int>(nullable: false),
                    ApiaryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beehives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Beehives_Apiaries_ApiaryID",
                        column: x => x.ApiaryID,
                        principalTable: "Apiaries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaPlants_ApiaryID",
                table: "AreaPlants",
                column: "ApiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Beehives_ApiaryID",
                table: "Beehives",
                column: "ApiaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaPlants");

            migrationBuilder.DropTable(
                name: "Beehives");

            migrationBuilder.DropTable(
                name: "Apiaries");
        }
    }
}
