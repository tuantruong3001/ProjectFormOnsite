using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFormOnsite.Migrations
{
    /// <inheritdoc />
    public partial class updatenewdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Onsite_ApproverID",
                table: "Onsite",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Onsite_EmployeeID",
                table: "Onsite",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee");

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

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee");
        }
    }
}
