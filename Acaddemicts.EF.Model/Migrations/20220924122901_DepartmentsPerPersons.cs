using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acaddemicts.EF.Model.Migrations
{
    public partial class DepartmentsPerPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AdministratorId",
                table: "Departments",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Persons_AdministratorId",
                table: "Departments",
                column: "AdministratorId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Persons_AdministratorId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_AdministratorId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Departments");
        }
    }
}
