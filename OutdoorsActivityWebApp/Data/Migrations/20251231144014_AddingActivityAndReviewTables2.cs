using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutdoorsActivityWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingActivityAndReviewTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstructorId",
                table: "Activities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_InstructorId",
                table: "Activities",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_InstructorId",
                table: "Activities",
                column: "InstructorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_InstructorId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_InstructorId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Activities");
        }
    }
}
