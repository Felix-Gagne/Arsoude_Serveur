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
                value: "7b956d01-843a-476d-b6b7-014bd79d4547");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fb6664d-c479-4e88-8c28-ee894e95f7c2", "AQAAAAEAACcQAAAAEBui39m2RmdMVu7NcGDr1gsNBAKe87RRZt6EI1JQVj5PlcYYgTZPPbzzXRQEL4YFog==", "20e14b8d-f00c-44ad-abc4-103cd5398238" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb98cf6c-62e3-4ee0-b651-28dc66daa18a", "AQAAAAEAACcQAAAAED0GQu4cbitZjbK4xn6tuJe9icMbQCTIk6o7xFYUY7LhnOFDsKjqsgz+UCVmSHi22A==", "577defdb-6e12-44cb-b791-6c8fd2c890b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "fae9d43c-3ac6-4bb5-ba4c-fec062f68247");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "faac6b15-a8c1-475b-a56c-616952ad3c11", "AQAAAAEAACcQAAAAEOJwF4RfVHwJlV8Jr2Bg0c/JJU0SydAVMywU+xPgV3B5GBMiIEByqKk1ckzN2SOdxA==", "dab44280-79f4-41fb-ac66-33ed290a6a80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdd3511b-4bb5-451f-9378-40dc6695a612", "AQAAAAEAACcQAAAAECUDRaN85Pifu39uZ/mf5ESCRCG0r4AckFMiOWwXtkdSR7whzUtYmzgyoAjK3GP1tA==", "5fe12c2a-bcca-43d5-a077-636bddd998cd" });
        }
    }
}
