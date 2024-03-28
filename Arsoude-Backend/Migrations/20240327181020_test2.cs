using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111113",
                column: "ConcurrencyStamp",
                value: "5c40002d-2bbc-4035-b306-ad3819f7b46c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa613c49-d1aa-4fc5-b9de-4828f55351bb", "AQAAAAEAACcQAAAAEM7gBSXa8In0K+FmKldKkTBrInj5EBP1AS7ZHkua89BzF1ZlfYtR31lqhXrdP5IQfw==", "20225356-b9fc-44cd-b88d-0d46d188e778" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0679491-38bf-4819-8c30-cf34614a42e6", "AQAAAAEAACcQAAAAEMBfsPQv1caM+SV9F4eJJb1FPv1SXTxv5GTqgjByqSi5qYZSiUD0xOTPFY7o5JDcEg==", "c8d4a951-19d9-4d1e-8168-4966411b0b06" });
        }
    }
}
