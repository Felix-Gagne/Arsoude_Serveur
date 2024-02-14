using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class trailSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "612e1345-4912-4349-ac74-62beb6fef393");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a109cb57-524f-408b-ad60-85e00e31cc82", "AQAAAAEAACcQAAAAENokstif0+TUWHP2NYPndjQz1OwSqQrqKlkkboLw7bO8TPLvDzIU3urMVGnT3AN2/w==", "7cbb2aba-3325-4482-b7f6-17a13b2369ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da5d80cc-7694-4dc8-b11a-3e18eaf92037", "AQAAAAEAACcQAAAAEKUugeR+YOGNGcLy5laHeJD5C/XkfBcPxgR67f5DRFmWaRSLS+2450gZjV+GhbHZew==", "5ac07a5d-e3c1-4dd4-8159-89622a958251" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "07eeb09c-a833-47a0-8152-183bf1b2679e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c93b054-afce-4066-b592-834d7b250edb", "AQAAAAEAACcQAAAAEO3ZUHUOKASm+aFoNA/Kpqa938fK8mGYym+mxFWoxZtvBssi861eYF1pJc6X2/PNaA==", "01b28cc9-99e0-4cb7-ae05-5b68011df932" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f0cf4f9-6b92-4ef4-b618-8a34687fde71", "AQAAAAEAACcQAAAAEPzdmo2BpXK5SrAkVN2P3ltF8CysxLJI0IptUcGn5++YRHTkebxNy++0bm6AW08fFg==", "2a59e2e6-64f4-4c94-ba3b-d1cf5defe45d" });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "Description", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "StartingCoordinatesId", "Type", "UserId", "isPublic" },
                values: new object[] { 1, "UNE MECHANT GROS TRAJET", 2, null, null, "Bar chez Diane", "TestTrail", 1, 1, 0, null, false });
        }
    }
}
