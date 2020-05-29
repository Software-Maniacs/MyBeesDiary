using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBeesDiary.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaPlants_Apiaries_ApiaryID",
                table: "AreaPlants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaPlants",
                table: "AreaPlants");

            migrationBuilder.DropIndex(
                name: "IX_AreaPlants_ApiaryID",
                table: "AreaPlants");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "AreaPlants");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AreaPlants");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Apiaries");

            migrationBuilder.AddColumn<int>(
                name: "Feedings",
                table: "Beehives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Beehives",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Beehives",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reviews",
                table: "Beehives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stores",
                table: "Beehives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Treatments",
                table: "Beehives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ApiaryID",
                table: "AreaPlants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantsID",
                table: "AreaPlants",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Production",
                table: "Apiaries",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Apiaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Apiaries",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaPlants",
                table: "AreaPlants",
                column: "PlantsID");

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    PlantName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaPlants_ApiaryID",
                table: "AreaPlants",
                column: "ApiaryID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AreaPlants_Apiaries_ApiaryID",
                table: "AreaPlants",
                column: "ApiaryID",
                principalTable: "Apiaries",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaPlants_Apiaries_ApiaryID",
                table: "AreaPlants");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaPlants",
                table: "AreaPlants");

            migrationBuilder.DropIndex(
                name: "IX_AreaPlants_ApiaryID",
                table: "AreaPlants");

            migrationBuilder.DropColumn(
                name: "Feedings",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "Reviews",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "Stores",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "Treatments",
                table: "Beehives");

            migrationBuilder.DropColumn(
                name: "PlantsID",
                table: "AreaPlants");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Apiaries");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Apiaries");

            migrationBuilder.AlterColumn<int>(
                name: "ApiaryID",
                table: "AreaPlants",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "AreaPlants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AreaPlants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Production",
                table: "Apiaries",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "Apiaries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaPlants",
                table: "AreaPlants",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_AreaPlants_ApiaryID",
                table: "AreaPlants",
                column: "ApiaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaPlants_Apiaries_ApiaryID",
                table: "AreaPlants",
                column: "ApiaryID",
                principalTable: "Apiaries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
