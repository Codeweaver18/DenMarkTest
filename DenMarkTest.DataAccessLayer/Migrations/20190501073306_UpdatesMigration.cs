using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DenMarkTest.DataAccessLayer.Migrations
{
    public partial class UpdatesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "testName",
                table: "Tests",
                newName: "testType");

            migrationBuilder.AddColumn<DateTime>(
                name: "testDate",
                table: "Tests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testDate",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "testType",
                table: "Tests",
                newName: "testName");
        }
    }
}
