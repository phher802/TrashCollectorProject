using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorInc.Data.Migrations
{
    public partial class AddCustomerAndEmployeeIdentityRolesToApplicaitonDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfae473-2e78-436f-b671-c3665f0c3b83");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02fcd5c2-17bb-49d1-b0ec-522f7a55bcc1", "bda51bbc-8c62-4f64-aa90-08750f094db5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0b83f357-090b-40f8-b47a-a78301db6d68", "ff2a2318-20e9-4b27-9d1d-a4f80fe5e091", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02fcd5c2-17bb-49d1-b0ec-522f7a55bcc1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b83f357-090b-40f8-b47a-a78301db6d68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cfae473-2e78-436f-b671-c3665f0c3b83", "748832d9-c8e2-43d5-9c4d-d0d7a70b9197", "ADMIN", "ADMIN" });
        }
    }
}
