using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorInc.Data.Migrations
{
    public partial class AddCustomerAndEmployeeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02957dfd-8bae-46ea-9955-bcca849a8e8e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ab51054-e2e8-4e12-8218-d29274a051f2", "45d9dbe5-f2a1-4631-8087-00bc736f14ab", "ADMIN", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ab51054-e2e8-4e12-8218-d29274a051f2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02957dfd-8bae-46ea-9955-bcca849a8e8e", "90e66104-b315-4e74-bcc4-b8d3ea14e344", "ADMIN", "ADMIN" });
        }
    }
}
