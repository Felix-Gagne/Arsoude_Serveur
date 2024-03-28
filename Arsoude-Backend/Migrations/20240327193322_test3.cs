using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrailRatingUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false),
                    VoteValue = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailRatingUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "31d2c198-a5d8-4f1d-b9a7-a613d61c619c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0185283-fa90-4dd8-aac2-26dfdea85dd0", "AQAAAAEAACcQAAAAEEXSES6bMbqCJ952hM6I40F+IAA5UDdBgU3NJEVq4MSPLVjaGgwJe3VTQNc+J1Ag7w==", "4785a578-4e82-4ae3-a416-1c9ec796bd82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbb8fd41-bfee-4ba9-9ab9-459d7d0dacaf", "AQAAAAEAACcQAAAAEARK9k18clW0E4TEceQz3q7KP2tMX4hsJg9ZYRlyyjmzVJsBSSAmTYC6NoBRvISiaQ==", "ca675a69-2df1-4f46-bb83-2faeae30e09d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailRatingUser");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "428e09b5-a208-481b-bd29-c035398edc46");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74d63021-c744-4d2d-9ae0-34b6c0173e19", "AQAAAAEAACcQAAAAEMhu1/taRSpyRrp/BSFpfFNxp1Df7odna20o1TdKQy1Mq4qNt0jF2qUGWcSYdY0CTA==", "6cceb1fa-2975-4adf-aa2e-867fa9313ac7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bfb94db-01ec-4729-938a-31d73f54c098", "AQAAAAEAACcQAAAAEBFd8FozRvmYENHreK9kr/9Dt5tPZ+UFKOuIbwpiSKAjFvT69q/86d4sVkdq1r2j4A==", "f1e24da1-9421-4370-9d2e-b2f0c6ebd257" });
        }
    }
}
