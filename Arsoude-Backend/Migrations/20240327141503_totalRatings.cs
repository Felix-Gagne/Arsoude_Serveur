using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class totalRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalRatings",
                table: "Trails",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "2561ecf7-faac-4648-bfa9-ba1daaff9a67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15627a42-1240-48b7-a657-402bf3b1a67b", "AQAAAAEAACcQAAAAEBOpvDs4MewaJ+3KW3usCnmSyIV1MN/rwTdDZYscngWdjOpkPYKXNcM8H3Wskh90yw==", "a2dedc54-2aa6-4e2e-bcce-b48ba215a4b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2d5b662-7e7f-421f-8a7b-7b65ef1eb792", "AQAAAAEAACcQAAAAEIort8xI1/RxaOizu5iN3qXJ18mNigrJL8Hh2HfscbKLUY4gCNC/fw2fvuZU+r9vww==", "6cfbc254-08eb-47e8-b16b-6080388f4ac9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRatings",
                table: "Trails");

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
    }
}
