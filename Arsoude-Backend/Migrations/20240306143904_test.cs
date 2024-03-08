using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Comments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "fe4ebe67-37da-477f-aa61-6f639758d550");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e8998dc-c2f7-4c9c-93f1-fe901250a41c", "AQAAAAEAACcQAAAAEArj8S4nWlTP8jk1Sbq9sABQqEx1khBnAauIILlQ2ZdRxNMDbBTYuMkftDT71fUUIQ==", "46617e9d-a1b2-48f8-9937-be3079b3999a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "008d1a44-3595-46f1-8560-2797dbaac909", "AQAAAAEAACcQAAAAENAsQZwODsxQ2lMWM007RUrY8IaL++gzrfcUwe4n39ng8SyjjC9DH58TAKe6d9GgOg==", "a7579607-1bb7-47fe-8351-9d833afc29ea" });
        }
    }
}
