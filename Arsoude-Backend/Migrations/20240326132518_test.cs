using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "0bc0ab4a-2441-4c43-8952-f103fe87c9cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f051af4-2d25-43b3-b304-fb795b266ca5", "AQAAAAEAACcQAAAAEDgCY+roww8/m0khId4PCQ3WivUYUYGWuAXxe/NTnqdolMh/JBovjfxKTjDbVx2WBw==", "d7c062ec-84ab-4fb1-8c79-010a7fdfe44d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7b844fa-c673-430b-b28e-e54369a58dcc", "AQAAAAEAACcQAAAAENgJPW+yx4cgno5bHkrbQf2STqEAg1fbMRig41fZflMprKnsgeNugPyB4Sqt2TFP8g==", "8cb3709f-f629-4739-bc81-2012335a200d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "dac9ef57-3c9b-4655-8f80-bc6bf528eabc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9642f1e1-6760-4225-9a98-16bd81da6336", "AQAAAAEAACcQAAAAEIfhYlSsswLw6V/KM4Ihe6fRnWaLCrtElCHxfL8GJDBj3VK0hN+eVC5GX63zd6h06w==", "e840105f-5430-4483-8d5b-9386c390a849" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82170ac7-60c9-4e75-a322-a49543292355", "AQAAAAEAACcQAAAAEMEsEGSxslLV5QtX+3dirzq29fPq9qDRrZp+0XcYlQg+B63SiZNxykdJ6PtVF/Wk7w==", "2e89eba4-1538-4dbe-93bc-c5cb98be6666" });
        }
    }
}
