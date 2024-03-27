using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class ok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "48171196-8fa9-416d-b2b4-5ee9eae76816");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de975661-f2bb-45fc-859d-469e2a7496d5", "AQAAAAEAACcQAAAAEERvgFA7V1lq4m6myhfK6GZdhS2dQybFvVnruLMUECJN8rBfqD6w5n3Wgk6uLTNPCw==", "f551a014-36c4-4bc0-b91b-7659b2a781e9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "818f9492-3010-4230-bdd6-02e2db352685", "AQAAAAEAACcQAAAAELqZb4l+uBqWpF8vMo8ky/tdHdWV0chwIEQrIARlndF1fEbsW8FsHCppTebbJ1LGRg==", "b2a0c8df-30b1-4b25-ad1e-9d0eb8c834b0" });
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
