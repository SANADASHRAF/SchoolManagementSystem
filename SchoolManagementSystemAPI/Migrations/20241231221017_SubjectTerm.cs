using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class SubjectTerm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYears_Terms_TermID",
                table: "AcademicYears");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AcademicYears_AcademicYearID",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Terms_TermID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_AcademicYearID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TermID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYears_TermID",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "AcademicYearID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TermID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TermID",
                table: "AcademicYears");

            migrationBuilder.AddColumn<string>(
                name: "GradeLevel",
                table: "AcademicYears",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ssubjectTerm",
                columns: table => new
                {
                    SubjectTermID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    TermID = table.Column<int>(type: "int", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ssubjectTerm", x => x.SubjectTermID);
                    table.ForeignKey(
                        name: "FK_ssubjectTerm_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "YearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ssubjectTerm_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ssubjectTerm_Terms_TermID",
                        column: x => x.TermID,
                        principalTable: "Terms",
                        principalColumn: "TermID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ssubjectTerm_AcademicYearID",
                table: "ssubjectTerm",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_ssubjectTerm_SubjectID",
                table: "ssubjectTerm",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ssubjectTerm_TermID",
                table: "ssubjectTerm",
                column: "TermID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ssubjectTerm");

            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "AcademicYears");

            migrationBuilder.AddColumn<int>(
                name: "AcademicYearID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TermID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TermID",
                table: "AcademicYears",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AcademicYearID",
                table: "Subjects",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TermID",
                table: "Subjects",
                column: "TermID");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_TermID",
                table: "AcademicYears",
                column: "TermID");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicYears_Terms_TermID",
                table: "AcademicYears",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AcademicYears_AcademicYearID",
                table: "Subjects",
                column: "AcademicYearID",
                principalTable: "AcademicYears",
                principalColumn: "YearID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Terms_TermID",
                table: "Subjects",
                column: "TermID",
                principalTable: "Terms",
                principalColumn: "TermID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
