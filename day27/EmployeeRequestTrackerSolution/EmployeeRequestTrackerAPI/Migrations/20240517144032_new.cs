using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeId1",
                table: "Requests",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_EmployeeId1",
                table: "Requests",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_EmployeeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_EmployeeId1",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_EmployeeId1",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Requests");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
