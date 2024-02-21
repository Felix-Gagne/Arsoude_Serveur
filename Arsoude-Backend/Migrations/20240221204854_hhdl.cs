using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class hhdl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "cb83a749-aabb-4add-adc0-a8ee6e2ee5c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed1b8805-5005-4b2c-bf59-0f91172c9fce", "AQAAAAEAACcQAAAAEDiozaErF2HaIzadzdV0vEWVEaC+tGIzMFQV/g21n7zp4xttQK1rxnZZc9ybIXFG1w==", "15a63356-5513-49c0-afa3-a8aaebf07191" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2a94351-fbd7-4048-bf1f-29f21df37efc", "AQAAAAEAACcQAAAAEN64kZYk2i0VWXnwZAO3UIXN/kZLFT5f4duxjDcm5OWTqxrhD3XSeGf/AF43cntnIA==", "47d8c9dc-c67d-4033-9853-7520bb7d8dec" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "c519f58b-d056-4ab1-9005-bec8d1c615c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ef00445-8031-4189-bd62-793f4cf350e7", "AQAAAAEAACcQAAAAEEQLWvSav0drz8Cf4qNGlyozSvu1agD6OgNuAA8NMUP7dx4TXL+V1jRF06d3jhtMGQ==", "5ea2cf3c-4b22-42bb-9216-fe83761c1c43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38e4b5a2-4587-499f-b87d-93f1146d2289", "AQAAAAEAACcQAAAAEDEDCOm0oedAj6EIkxjy9oDFWQvccnBNS9HDOYni40YfAskfHurwVGRlivhDviQSzA==", "be73d46d-3e53-4a32-8c82-03c3c52729e2" });
        }
    }
}
