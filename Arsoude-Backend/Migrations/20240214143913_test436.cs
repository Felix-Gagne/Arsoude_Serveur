using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test436 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "5f919890-843d-4127-ade3-7eab5253e673");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78ab3cd1-93ea-45cd-8d97-d831ec396a87", "AQAAAAEAACcQAAAAEKLehiwIsmTPgnp4c1BmLL6VasdHiCPNbWwCkmL7VCFFjXw3QgO+f8/AMME6F5zwUA==", "d7bc2641-87b6-48c4-9b50-28d24d12b25d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5eeed27a-8bbe-4fe7-9d9d-9f6779d18d21", "AQAAAAEAACcQAAAAEHwkKZIo6fCbAJSOFscqTYJjRrvmfFUyLkmpf0DOtb5chJXiYuqUsnLzTZVmikbfMw==", "aa24a204-efe3-4185-99e2-9709cefccad0" });

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
        }
    }
}
