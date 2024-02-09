using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class trailVisibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPublic",
                table: "Trails",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "ec5bf71a-25cc-4e4c-b658-ea32d3608e0f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bef85f3-8f17-49f3-bb32-335d91d8b2e3", "AQAAAAEAACcQAAAAEJYepHMom21wROV64CVREwGrLhuckkcfWrjU3/UMY8E01fPYUbVkdCF5ILbRj3Qtiw==", "e7b0dd51-33f3-42f7-aca7-c21c61c04cf3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e9f28cb-cc44-4ea0-aa45-6ffc9c9ea436", "AQAAAAEAACcQAAAAECZ0eC5fE5dls272QJca9PQV/SfF7fzJ2bTqW3x3gJ1dxMK6zui8jT6C2NGNn/N/UQ==", "475a1def-7bb8-4dcc-8be9-49fbee94491a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPublic",
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
