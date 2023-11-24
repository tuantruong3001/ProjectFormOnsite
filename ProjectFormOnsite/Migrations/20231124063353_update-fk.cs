using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFormOnsite.Migrations
{
    /// <inheritdoc />
    public partial class updatefk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverEmployeeID",
                table: "Onsite",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Onsite_ApproverEmployeeID",
                table: "Onsite",
                column: "ApproverEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Onsite_Employee_ApproverEmployeeID",
                table: "Onsite",
                column: "ApproverEmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onsite_Employee_ApproverEmployeeID",
                table: "Onsite");

            migrationBuilder.DropIndex(
                name: "IX_Onsite_ApproverEmployeeID",
                table: "Onsite");

            migrationBuilder.DropColumn(
                name: "ApproverEmployeeID",
                table: "Onsite");
        }
    }
}
