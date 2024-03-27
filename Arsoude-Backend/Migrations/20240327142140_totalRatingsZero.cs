using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class totalRatingsZero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalRatings",
                table: "Trails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "508e7776-d044-4dbe-bbd7-97943f58b994");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0173e868-ca35-43be-91ad-de571bbb81fb", "AQAAAAEAACcQAAAAEALGk9b1I/1WZ8+smvA1Ia73UuHxT7c7kRbjsb3fWMWSYJE/ThkSa9FS8Rlz7KO7sg==", "e3465182-e378-4854-ba09-b3d837624a46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a1a5af-9abb-4490-8bc0-c745501ee16f", "AQAAAAEAACcQAAAAEDG3UOQJR7ovBnTJLCjkaoNoSdrQQtbEl7/aPBNytBpyHz21aRmOn5WsSsx5MkkZZw==", "372d60ad-588d-4845-abd1-fc39d2986722" });

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 31,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 32,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 33,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 34,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 35,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 36,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 37,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 38,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 39,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 40,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 41,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 42,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 43,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 45,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 46,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 47,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 48,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 49,
                column: "TotalRatings",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 50,
                column: "TotalRatings",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalRatings",
                table: "Trails",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 31,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 32,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 33,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 34,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 35,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 36,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 37,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 38,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 39,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 40,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 41,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 42,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 43,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 45,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 46,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 47,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 48,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 49,
                column: "TotalRatings",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 50,
                column: "TotalRatings",
                value: null);
        }
    }
}
