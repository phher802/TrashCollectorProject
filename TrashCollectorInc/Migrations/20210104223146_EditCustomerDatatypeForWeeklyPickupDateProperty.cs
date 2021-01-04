using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorInc.Migrations
{
    public partial class EditCustomerDatatypeForWeeklyPickupDateProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0489df08-e4ba-4116-80a8-ea6790c1e657", "37b385bd-0292-4102-851a-3059eccfbfe9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "622b7ac6-1b66-40e7-af79-d9d620fbdaf2", "5e965107-ea79-408d-bdf8-d689f73db0c5", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0489df08-e4ba-4116-80a8-ea6790c1e657");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "622b7ac6-1b66-40e7-af79-d9d620fbdaf2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8cad2a32-1891-471b-b158-cffe008ca9b2", "35b83002-80b4-4f13-a8e8-a293d56a0ca4", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db202534-cbac-4ee3-8a09-e9e0fb6eee7d", "5ac0f3f4-653c-40f4-9166-3e26d343a479", "Employee", "EMPLOYEE" });
        }
    }
}
