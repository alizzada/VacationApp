using Microsoft.EntityFrameworkCore.Migrations;

namespace AliExam.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_Departments_DepartmentId",
                table: "MyProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_MyProperty_EmployeesVacations_EmployeesVacationsId",
                table: "MyProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty");

            migrationBuilder.DropIndex(
                name: "IX_MyProperty_EmployeesVacationsId",
                table: "MyProperty");

            migrationBuilder.DropColumn(
                name: "EmployeesVacationsId",
                table: "MyProperty");

            migrationBuilder.RenameTable(
                name: "MyProperty",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_MyProperty_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "EmployeesVacations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesVacations_EmployeesId",
                table: "EmployeesVacations",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesVacations_Employees_EmployeesId",
                table: "EmployeesVacations",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesVacations_Employees_EmployeesId",
                table: "EmployeesVacations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesVacations_EmployeesId",
                table: "EmployeesVacations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "EmployeesVacations");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "MyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "MyProperty",
                newName: "IX_MyProperty_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesVacationsId",
                table: "MyProperty",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyProperty",
                table: "MyProperty",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MyProperty_EmployeesVacationsId",
                table: "MyProperty",
                column: "EmployeesVacationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_Departments_DepartmentId",
                table: "MyProperty",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProperty_EmployeesVacations_EmployeesVacationsId",
                table: "MyProperty",
                column: "EmployeesVacationsId",
                principalTable: "EmployeesVacations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
