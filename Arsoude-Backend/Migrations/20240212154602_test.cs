using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Trails",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Trails_UserId",
                table: "Trails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trails_TrailUsers_UserId",
                table: "Trails",
                column: "UserId",
                principalTable: "TrailUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trails_TrailUsers_UserId",
                table: "Trails");

            migrationBuilder.DropIndex(
                name: "IX_Trails_UserId",
                table: "Trails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Trails");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "10d08989-49c0-419c-9c62-53e812bb188b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c71ec99-7db6-4a8f-b692-336463262b6d", "AQAAAAEAACcQAAAAEOzSd/ofuCl0XVqcBC2B/WW2Q1ZObYVRBqBBzJl/mppMOsC9dQcYAiK4Nztbf6ZRdw==", "ac4554b6-8d3f-4355-a287-eb8518b0dd1b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66b182c6-729c-4287-8cb1-1bfab187e51a", "AQAAAAEAACcQAAAAEEN6qSqQaZKQMoFsw0nKLwQwMnbPgRiCpeM4u0wWBuMBxc1+hRAgryoiKQc9WF/0gg==", "b6edf8f5-5ba7-4932-892c-5cbb11af7143" });
        }
    }
}
