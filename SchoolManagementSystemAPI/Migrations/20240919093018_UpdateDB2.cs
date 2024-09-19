using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Cities_CityID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CityID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityID",
                table: "AspNetUsers",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityID",
                table: "AspNetUsers",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CityID",
                table: "Students",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Cities_CityID",
                table: "Students",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
