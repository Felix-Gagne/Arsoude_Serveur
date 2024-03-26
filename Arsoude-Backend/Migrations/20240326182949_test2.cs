using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "0fe47e85-9712-46b0-8df5-cdd4a05a2060");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41e850b4-985f-4184-8592-256ae951fe74", "AQAAAAEAACcQAAAAEGIB8aVsusoxdZNe28iBfyWCM7Nx8DcxaJau1MJnqQaFV09UBbg9H3lSjKy2VYXsxA==", "9cb957c5-3d80-482c-94a0-f7a805f1b3a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5d112b5-8e97-4994-a7d2-997c3d1bd3ac", "AQAAAAEAACcQAAAAEKdz0LvANghwxr0bKVr2E6BLUWTq9/PQ15NrrJJWcx0aeYiy0P5pnI8MWcnJcsaGPQ==", "ef0c8b54-5978-4aa0-9ce8-30ff8304b354" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "5583c49c-b0e0-4e98-9f72-40a5d4490fca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cdddfc3-f210-4133-829e-e278a29fe5e0", "AQAAAAEAACcQAAAAELNjawGPVnybe4Olz3NwmFnkxvdNUPDZ6s34/Wcvuyu6GiicVeDstQd6I2F/E6c9tA==", "6cf144b4-f77e-4fe5-80fa-35c74067707c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee147c63-893b-4a2e-aba5-9acef9a0f347", "AQAAAAEAACcQAAAAEJqaeUCzKP2HCDwiPmSqLGynwQTdnadSTDxdksglFjJlsCNSEqmhfTVnPcnKxOCZSA==", "71a02beb-4836-4dcb-b697-8f7dc2065771" });
        }
    }
}
