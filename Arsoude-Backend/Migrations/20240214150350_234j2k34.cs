using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class _234j2k34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coordinates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coordinates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coordinates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coordinates",
                keyColumn: "Id",
                keyValue: 6);

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
                value: "c9a715fd-6ba0-4622-aefb-efdc26743124");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a48e270-0c0b-4cff-a682-b8307bdb34a8", "AQAAAAEAACcQAAAAEAeYZXqsG2J/AbNTaIk5rpv+2IBpYoBrBxZNe+d7em9CEBTLsg1X5OYrIt6Z6kLKDA==", "a4a31557-567d-4ff0-944b-0aef1d84fd95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef9634d3-5633-4c48-ab9d-f15fe3de90b5", "AQAAAAEAACcQAAAAEMsEIpvSqVygPmDPHtovKOj9/XOdyg3x1YzGp9mbHjZNtUvnNK6aAoKmp2jZXDwjLA==", "08689a7a-5bea-4dfb-82b0-4abefbc3f874" });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndingCoordinatesId", "StartingCoordinatesId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndingCoordinatesId", "StartingCoordinatesId" },
                values: new object[] { 2, 1 });

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
                value: "9ee51442-5b15-4cb1-8449-2bda40d4ccc6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2db2693d-0ead-4943-8e07-1fc67cba7e1f", "AQAAAAEAACcQAAAAEP2k4SXezmnC5x/h+EijePTm8bQ/DvdtqOH+ALb6pnGd58m5iyGK07L8UCM1Eq9lxQ==", "ec798c4e-539d-4526-a5b6-62c0e66f8963" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20173418-81a2-4082-b2a1-96546729545e", "AQAAAAEAACcQAAAAEHT4ifFN2eEm3Yo6M1JSCdY/EeTjdrPKtwT7LeBMNF39n9AOhWlLjLEbLr4HlHFzgg==", "114b0d3a-9131-4704-8669-e8c0b2c4afeb" });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 3, 45.559601999999998, -73.580235999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 4, 45.671821999999999, -73.526653999999994, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 5, 45.559601999999998, -73.580235999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 6, 45.671821999999999, -73.526653999999994, null });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndingCoordinatesId", "StartingCoordinatesId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndingCoordinatesId", "StartingCoordinatesId" },
                values: new object[] { 6, 5 });
        }
    }
}
