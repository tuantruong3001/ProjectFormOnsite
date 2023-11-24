using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFormOnsite.Migrations
{
    /// <inheritdoc />
    public partial class fixdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onsite_Employee_ApproverID",
                table: "Onsite");

            migrationBuilder.DropForeignKey(
                name: "FK_Onsite_Employee_EmployeeID",
                table: "Onsite");

            migrationBuilder.DropIndex(
                name: "IX_Onsite_ApproverID",
                table: "Onsite");

            migrationBuilder.DropIndex(
                name: "IX_Onsite_EmployeeID",
                table: "Onsite");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Onsite_ApproverID",
                table: "Onsite",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Onsite_EmployeeID",
                table: "Onsite",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Onsite_Employee_ApproverID",
                table: "Onsite",
                column: "ApproverID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Onsite_Employee_EmployeeID",
                table: "Onsite",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
