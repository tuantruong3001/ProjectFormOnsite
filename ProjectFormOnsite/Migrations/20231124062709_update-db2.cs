using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFormOnsite.Migrations
{
    /// <inheritdoc />
    public partial class updatedb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Onsite_ApproverID",
                table: "Onsite",
                column: "ApproverID");

            migrationBuilder.AddForeignKey(
                name: "FK_Onsite_Employee_ApproverID",
                table: "Onsite",
                column: "ApproverID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onsite_Employee_ApproverID",
                table: "Onsite");

            migrationBuilder.DropIndex(
                name: "IX_Onsite_ApproverID",
                table: "Onsite");
        }
    }
}
