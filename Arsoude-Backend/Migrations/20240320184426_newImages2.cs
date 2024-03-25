using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class newImages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "c0a860fb-e022-41e0-b3ef-9703a793f890");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e654279-30aa-4393-b822-59d527d41432", "AQAAAAEAACcQAAAAEOM4OOf0C5GTNNYhD3wwEx4l4EyRlmDsLkRLdcp92IIJCGLcIzZUUXC6VKLF0X3R3Q==", "35d5f160-88ff-43ad-823e-558566a13865" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39efd774-eb92-4acd-86e8-748bd3f68f7d", "AQAAAAEAACcQAAAAEDtsfKpeyuqCPK6bObeTuZk8Lya2kR5ycrEXSLfiEUSyWF3z0xkV6/g+rla9oz/nsw==", "840b6048-a3b4-4c6a-b53c-f60e29345a57" });

            migrationBuilder.UpdateData(
                table: "TrailImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://blog.ab.bluecross.ca/wp-content/uploads/2020/08/fav-hikes-part-three.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "TrailImages",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.tourismpei.com/sites/default/files/styles/hero_mobile/public/media/images/51271316495_139f7c6199_o_s0.jpg?h=3cbfe8df&itok=dRMEGC9G");
        }
    }
}
