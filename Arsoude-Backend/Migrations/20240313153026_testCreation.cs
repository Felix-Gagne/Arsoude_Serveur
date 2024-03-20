using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class testCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "03f78a79-c1e1-4d8d-9d31-c515ce8b89f5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f1dd599-15b1-44ce-9717-72610b16a80d", "AQAAAAEAACcQAAAAEB13v1Cy60nfwt2tYkWIM4Gg7BFb7zTx+tbDuqy0q1M2MJZl07Bu3ncjR3v9TdC7zA==", "c0757aaf-aa8b-4532-adcc-00b119a90175" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ef62cc9-d6e2-4198-ab3a-6e0491242ece", "AQAAAAEAACcQAAAAEDcxlp2GzPKIwoCzfCXetAllVbetq8+Dp2GZ80yvmWQmaov2b1BaWTeg3So7Hny5eA==", "64e79627-a048-43c2-b83f-f4a20c66c2e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "cdfbf36f-cb1a-41a0-b3c8-8fb717d8c165");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b687235-b2b5-4115-9630-ed392264cd58", "AQAAAAEAACcQAAAAEF4Jj7DexKprkLhRJ3Jth/46W7nvuPfTiDHq4VinVoXnp1Oof290hAk+vPHZDJWpZg==", "49f5b766-cc56-4324-a63f-a5df89db826a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abf7ed0d-7ce7-4fd0-8041-8f26d2743635", "AQAAAAEAACcQAAAAEHbASIlpW5ncOZ4EfRwS9shTa/R4M1uYllRVCejqZ7EFquzVWd/MAKvCb7/qDhFHFQ==", "d9ec2446-ede4-4215-8189-8e9969790eef" });
        }
    }
}
