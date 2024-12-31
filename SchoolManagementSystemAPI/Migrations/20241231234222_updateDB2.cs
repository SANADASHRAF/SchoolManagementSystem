using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ssubjectTerm_AcademicYears_AcademicYearID",
                table: "ssubjectTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_ssubjectTerm_Subjects_SubjectID",
                table: "ssubjectTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_ssubjectTerm_Terms_TermID",
                table: "ssubjectTerm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ssubjectTerm",
                table: "ssubjectTerm");

            migrationBuilder.RenameTable(
                name: "ssubjectTerm",
                newName: "subjectTerm");

            migrationBuilder.RenameIndex(
                name: "IX_ssubjectTerm_TermID",
                table: "subjectTerm",
                newName: "IX_subjectTerm_TermID");

            migrationBuilder.RenameIndex(
                name: "IX_ssubjectTerm_SubjectID",
                table: "subjectTerm",
                newName: "IX_subjectTerm_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_ssubjectTerm_AcademicYearID",
                table: "subjectTerm",
                newName: "IX_subjectTerm_AcademicYearID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subjectTerm",
                table: "subjectTerm",
                column: "SubjectTermID");

            migrationBuilder.AddForeignKey(
                name: "FK_subjectTerm_AcademicYears_AcademicYearID",
                table: "subjectTerm",
                column: "AcademicYearID",
                principalTable: "AcademicYears",
                principalColumn: "YearID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subjectTerm_Subjects_SubjectID",
                table: "subjectTerm",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subjectTerm_Terms_TermID",
                table: "subjectTerm",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subjectTerm_AcademicYears_AcademicYearID",
                table: "subjectTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_subjectTerm_Subjects_SubjectID",
                table: "subjectTerm");

            migrationBuilder.DropForeignKey(
                name: "FK_subjectTerm_Terms_TermID",
                table: "subjectTerm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subjectTerm",
                table: "subjectTerm");

            migrationBuilder.RenameTable(
                name: "subjectTerm",
                newName: "ssubjectTerm");

            migrationBuilder.RenameIndex(
                name: "IX_subjectTerm_TermID",
                table: "ssubjectTerm",
                newName: "IX_ssubjectTerm_TermID");

            migrationBuilder.RenameIndex(
                name: "IX_subjectTerm_SubjectID",
                table: "ssubjectTerm",
                newName: "IX_ssubjectTerm_SubjectID");

            migrationBuilder.RenameIndex(
                name: "IX_subjectTerm_AcademicYearID",
                table: "ssubjectTerm",
                newName: "IX_ssubjectTerm_AcademicYearID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ssubjectTerm",
                table: "ssubjectTerm",
                column: "SubjectTermID");

            migrationBuilder.AddForeignKey(
                name: "FK_ssubjectTerm_AcademicYears_AcademicYearID",
                table: "ssubjectTerm",
                column: "AcademicYearID",
                principalTable: "AcademicYears",
                principalColumn: "YearID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ssubjectTerm_Subjects_SubjectID",
                table: "ssubjectTerm",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ssubjectTerm_Terms_TermID",
                table: "ssubjectTerm",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
