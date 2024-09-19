using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademicYearID",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_AcademicYearID",
                table: "Attendances",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TeacherID",
                table: "Attendances",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AcademicYears_AcademicYearID",
                table: "Attendances",
                column: "AcademicYearID",
                principalTable: "AcademicYears",
                principalColumn: "YearID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Teachers_TeacherID",
                table: "Attendances",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AcademicYears_AcademicYearID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Teachers_TeacherID",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_AcademicYearID",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_TeacherID",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "AcademicYearID",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Attendances");
        }
    }
}
