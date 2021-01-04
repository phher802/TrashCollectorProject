using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorInc.Migrations
{
    public partial class editPropertyTypeOfTheweeklyPickkupDayproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1edc57e1-9e60-4b0c-af6e-bb977a851a87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc9e374f-437b-4e12-8c68-c48e35960267");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c262b147-577d-430e-a13c-f748b41b4e4b", "63d4532f-a446-40b7-a32c-d4d875ee9829", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa74a270-572b-4026-93c2-c61336825193", "b3a950a2-a554-4d59-9b89-a3f3c6108a90", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c262b147-577d-430e-a13c-f748b41b4e4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa74a270-572b-4026-93c2-c61336825193");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1edc57e1-9e60-4b0c-af6e-bb977a851a87", "3d73eaee-14d3-48da-83e5-c11fe4abca17", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc9e374f-437b-4e12-8c68-c48e35960267", "6dd9af14-7720-42fc-8654-b1526d392845", "Employee", "EMPLOYEE" });
        }
    }
}
