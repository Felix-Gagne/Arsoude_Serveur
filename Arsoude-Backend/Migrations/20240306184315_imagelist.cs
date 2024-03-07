using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class imagelist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "af5250e2-d6fe-4c8a-847e-1fdf7020073e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81d4c933-3a45-42eb-967f-6613cb7eff40", "AQAAAAEAACcQAAAAEF/NIJeg4YtSDZqfPAPUgstjKe2/ptFHyj5bICVAGm9Oa3NuJTjbn3NCt3r0Zor2Zw==", "04cd48c5-40e5-4509-be31-cab8616f1aef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e609a534-2dbb-4799-8098-01ff7996373e", "AQAAAAEAACcQAAAAELSWXfub46jqp60VXgnOsMS/iUIdhY4+5hlnliN1REoCBDe4a+J7gE5YK2+JnG4xyQ==", "0e55b274-6444-46b8-b52d-5d84af481784" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "a8d6d083-f7a2-4655-b089-0ec52054c876");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8fe9b89-03f7-4703-a0b4-3909aaf00a56", "AQAAAAEAACcQAAAAEAYTIpGr86Qepzr1KEjAe1Ck5POI3Ts+kZtEffAAOcA5XGgzc9opotyHwJ654FfyOw==", "0a138025-4344-4adb-9c29-8e68511ebf49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb69eef0-a4dd-49ee-8fab-bb68c04780bd", "AQAAAAEAACcQAAAAEMaWOLTAd0NmjV2ae9dWLvkLhm32EbCn61mwJSBRVDuHUf7rgxMfQN81JR0YDrskpQ==", "e001d2cd-4c91-4c51-9395-5f514fd96153" });
        }
    }
}
