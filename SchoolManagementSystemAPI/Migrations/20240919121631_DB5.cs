using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class DB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HomeworkSubmissionUrlFilePath",
                table: "HomeworkSubmissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkSubmissionUrlImagPath",
                table: "HomeworkSubmissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkUrlFilePath",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkUrlImagPath",
                table: "Homeworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamSubmissionUrlFilePath",
                table: "ExamSubmissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamSubmissionUrlImagPath",
                table: "ExamSubmissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamUrlFilePath",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExamUrlImagPath",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeworkSubmissionUrlFilePath",
                table: "HomeworkSubmissions");

            migrationBuilder.DropColumn(
                name: "HomeworkSubmissionUrlImagPath",
                table: "HomeworkSubmissions");

            migrationBuilder.DropColumn(
                name: "HomeworkUrlFilePath",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "HomeworkUrlImagPath",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "ExamSubmissionUrlFilePath",
                table: "ExamSubmissions");

            migrationBuilder.DropColumn(
                name: "ExamSubmissionUrlImagPath",
                table: "ExamSubmissions");

            migrationBuilder.DropColumn(
                name: "ExamUrlFilePath",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExamUrlImagPath",
                table: "Exams");
        }
    }
}
