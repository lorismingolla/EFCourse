using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acaddemicts.EF.Model.Migrations
{
    public partial class CourseGradeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrade_Courses_CourseId",
                table: "CourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrade_Persons_StudentId",
                table: "CourseGrade");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrade_Courses_CourseId",
                table: "CourseGrade",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrade_Persons_StudentId",
                table: "CourseGrade",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrade_Courses_CourseId",
                table: "CourseGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGrade_Persons_StudentId",
                table: "CourseGrade");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrade_Courses_CourseId",
                table: "CourseGrade",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGrade_Persons_StudentId",
                table: "CourseGrade",
                column: "StudentId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }
    }
}
