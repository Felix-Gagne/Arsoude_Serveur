using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class newImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrailImages_Trails_trailId",
                table: "TrailImages");

            migrationBuilder.DropIndex(
                name: "IX_TrailImages_trailId",
                table: "TrailImages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "cd8a5fe5-2b4e-4e63-9b4f-f5fbe9892282");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dde022f-1e0b-4d3c-bb87-f456714dfcd5", "AQAAAAEAACcQAAAAELifqvVoNDzc+5/LBoA4V1Fcm3qaM5NKwTul8PXgVT1KKgLX8RcW9SISDry8Fhl4Yg==", "274ba1e8-7af3-4b3c-b8fb-836c1415b202" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b715b740-d17b-4d08-91ca-064b62f5d4d9", "AQAAAAEAACcQAAAAEIAhMdbECm2kwigrhGwafs+XtSQTszYDn+1Xpz/oNKTxWPaFcVkKGABw5fUmaI8EDw==", "97392d49-aeff-461d-b0d0-b2b976fad1c3" });

            migrationBuilder.InsertData(
                table: "TrailImages",
                columns: new[] { "Id", "ImageUrl", "trailId" },
                values: new object[] { 4, "https://www.tourismpei.com/sites/default/files/styles/hero_mobile/public/media/images/51271316495_139f7c6199_o_s0.jpg?h=3cbfe8df&itok=dRMEGC9G", 2 });

            migrationBuilder.InsertData(
                table: "TrailImages",
                columns: new[] { "Id", "ImageUrl", "trailId" },
                values: new object[] { 5, "https://i.cbc.ca/1.4170049.1530218327!/fileImage/httpImage/hiking-trails.jpg", 2 });

            migrationBuilder.InsertData(
                table: "TrailImages",
                columns: new[] { "Id", "ImageUrl", "trailId" },
                values: new object[] { 6, "https://www.surrey.ca/sites/default/files/styles/metatag_facebook/public/2020-08/InvergarryNatureTrail.JPG?h=d262251e&itok=oXPbDLYW", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrailImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrailImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrailImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "e10fdd50-7589-4232-8d04-4e15ece9ba67");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63da95a7-9062-4171-9cbe-ac30cb4a69bb", "AQAAAAEAACcQAAAAEFv+r0txub3uXX1Hr2bNwtVfTylVTl4YXbGp2Q/D0YVZtNxBSaBV+htGoIL/g46zBA==", "aa6c4ee8-b263-4c1f-a169-3dbde2e20977" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40bdc9f4-e6a4-4830-b0ca-47e71bceeea7", "AQAAAAEAACcQAAAAEI9/iWyrGXL4PvOive+YxA9FKcoEMcDBHjZDJIjunZD49TYeeYb6IfWYMk0si3+OmA==", "700bdf6f-6833-49f9-a965-20759a6700a8" });

            migrationBuilder.CreateIndex(
                name: "IX_TrailImages_trailId",
                table: "TrailImages",
                column: "trailId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrailImages_Trails_trailId",
                table: "TrailImages",
                column: "trailId",
                principalTable: "Trails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
