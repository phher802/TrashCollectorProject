using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorInc.Migrations
{
    public partial class EditEmployeeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c262b147-577d-430e-a13c-f748b41b4e4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa74a270-572b-4026-93c2-c61336825193");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8cad2a32-1891-471b-b158-cffe008ca9b2", "35b83002-80b4-4f13-a8e8-a293d56a0ca4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db202534-cbac-4ee3-8a09-e9e0fb6eee7d", "5ac0f3f4-653c-40f4-9166-3e26d343a479", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cad2a32-1891-471b-b158-cffe008ca9b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db202534-cbac-4ee3-8a09-e9e0fb6eee7d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c262b147-577d-430e-a13c-f748b41b4e4b", "63d4532f-a446-40b7-a32c-d4d875ee9829", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa74a270-572b-4026-93c2-c61336825193", "b3a950a2-a554-4d59-9b89-a3f3c6108a90", "Employee", "EMPLOYEE" });
        }
    }
}
