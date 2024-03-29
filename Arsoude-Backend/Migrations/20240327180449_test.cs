﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arsoude_Backend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrailUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    AreaCode = table.Column<string>(type: "TEXT", nullable: false),
                    HouseNo = table.Column<int>(type: "INTEGER", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    YearOfBirth = table.Column<int>(type: "INTEGER", nullable: true),
                    MonthOfBirth = table.Column<int>(type: "INTEGER", nullable: true),
                    IdentityUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrailUsers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrentLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Experience = table.Column<int>(type: "INTEGER", nullable: false),
                    PreviousLevelExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    NextLevelExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_TrailUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TrailUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteTrails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoriteTrails_TrailUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TrailUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    userHasCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_TrailUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TrailUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    StartingCoordinatesId = table.Column<int>(type: "INTEGER", nullable: false),
                    EndingCoordinatesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    isPublic = table.Column<bool>(type: "INTEGER", nullable: false),
                    Distance = table.Column<double>(type: "REAL", nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: true),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    TotalRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trails_Coordinates_EndingCoordinatesId",
                        column: x => x.EndingCoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trails_Coordinates_StartingCoordinatesId",
                        column: x => x.StartingCoordinatesId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trails_TrailUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TrailUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<int>(type: "INTEGER", nullable: false),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hikes_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hikes_TrailUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TrailUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrailImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    TrailId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrailImages_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11111111-1111-1111-1111-111111111113", "5c40002d-2bbc-4035-b306-ad3819f7b46c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "aa613c49-d1aa-4fc5-b9de-4828f55351bb", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEM7gBSXa8In0K+FmKldKkTBrInj5EBP1AS7ZHkua89BzF1ZlfYtR31lqhXrdP5IQfw==", null, false, "20225356-b9fc-44cd-b88d-0d46d188e778", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", 0, "a0679491-38bf-4819-8c30-cf34614a42e6", "user@user.com", true, false, null, "USER@USER.COM", "USER@USER.COM", "AQAAAAEAACcQAAAAEMBfsPQv1caM+SV9F4eJJb1FPv1SXTxv5GTqgjByqSi5qYZSiUD0xOTPFY7o5JDcEg==", null, false, "c8d4a951-19d9-4d1e-8168-4966411b0b06", false, "user@user.com" });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 1, 45.559601999999998, -73.580235999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 2, 45.671821999999999, -73.526653999999994, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 3, 48.909387000000002, -75.818077000000002, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 4, 48.806409000000002, -75.914644999999993, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 5, 48.969093000000001, -76.906711999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 6, 48.925913999999999, -76.893321999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 7, 45.928130000000003, -74.044250000000005, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 8, 45.923990000000003, -74.041640000000001, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 9, 45.892060000000001, -74.159469999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 10, 46.341439999999999, -74.267880000000005, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 11, 48.568269999999998, -64.306809999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 12, 48.574312999999997, -64.352936999999997, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 13, 48.568269999999998, -64.306809999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 14, 48.808650999999998, -64.220134000000002, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 15, 49.227136000000002, -65.920732999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 16, 49.193142000000002, -65.902365000000003, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 17, 51.545589999999997, -69.132334999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 18, 51.160510000000002, -69.023844999999994, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 19, 51.545589999999997, -69.132334999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 20, 51.160510000000002, -69.023844999999994, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 21, 51.545589999999997, -69.132334999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 22, 51.160510000000002, -69.023844999999994, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 23, 54.012407000000003, -82.219065999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 24, 55.002626999999997, -82.279490999999993, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 25, 62.838535, -91.898669999999996, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 26, 63.303736000000001, -90.769824999999997, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 27, 74.022659000000004, -41.820591999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 28, 75.560384999999997, -31.515416999999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 29, 68.110088000000005, 23.315586, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 30, 67.879562000000007, 23.189229000000001, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 31, 69.151650000000004, 106.003671, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 32, 59.895603000000001, 104.905038, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 33, 29.240485, -114.689688, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 34, 23.807555000000001, -110.657706, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 35, -11.490477, -37.386364, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 36, -12.838269, -38.243298000000003, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 37, -18.224066000000001, 49.397387000000002, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 38, -20.637858000000001, 48.529466999999997, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 39, 10.71109, 51.120646999999998, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 40, 6.6828969999999996, 49.088177000000002, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 41, 38.587606999999998, 128.37471199999999, null });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Latitude", "Longitude", "TrailId" },
                values: new object[] { 42, 38.404083, 128.45505, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-111111111113", "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11111111-1111-1111-1111-111111111113", "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.InsertData(
                table: "TrailUsers",
                columns: new[] { "Id", "AreaCode", "City", "FirstName", "HouseNo", "IdentityUserId", "LastName", "MonthOfBirth", "State", "Street", "YearOfBirth" },
                values: new object[] { 1, "111 111", null, "Test", null, "11111111-1111-1111-1111-111111111112", "Test", null, null, null, null });

            migrationBuilder.InsertData(
                table: "TrailUsers",
                columns: new[] { "Id", "AreaCode", "City", "FirstName", "HouseNo", "IdentityUserId", "LastName", "MonthOfBirth", "State", "Street", "YearOfBirth" },
                values: new object[] { 99, "A1A 1A1", null, "Admin", null, "11111111-1111-1111-1111-111111111111", "Admin", null, null, null, null });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 2, null, "Une randonnée pittoresque à travers une forêt luxuriante où les oiseaux chantent et les rivières murmurent.", null, 2, "https://www.parksconservancy.org/sites/default/files/styles/basic/public/programs/A_PRSF_111020_MCu_020-2104x1440.jpg?itok=Cp14Z3ba", null, "Parc National de la Forêt Verte", "Sentier de la Forêt Enchantée", 1, null, 1, 0, 0, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 3, null, "Une aventure difficile menant au sommet d'une montagne majestueuse offrant une vue imprenable sur la vallée ci-dessous.", null, 4, "https://cdn.kimkim.com/files/a/images/47739a6ddfef20df8e214fb3bd457adf1f27feab/original-fd1e0fff538a1dd6ebb2ab679ffbab4d.jpg", null, "Parc National des Montagnes Escarpées", "Escapade au Sommet", 1, null, 3, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 31, null, "Une randonnée enchanteresse le long de plusieurs cascades étincelantes, où l'eau scintille au soleil et crée un spectacle magique. Ce sentier offre une expérience sensorielle unique avec le bruit apaisant de l'eau qui coule, les reflets chatoyants et la fraîcheur de l'air pur. Vous serez transporté dans un monde de beauté naturelle et de tranquillité.", null, 6, "https://californiathroughmylens.com/wp-content/uploads/2019/05/crystal-cove-el-moro-12-640x427.jpg", null, "Parc National des Cascades Étincelantes", "Sentier des Cascades Étincelantes", 1, null, 5, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 32, null, "Une promenade pittoresque à travers de vastes champs de fleurs colorées, où vous pourrez vous imprégner des parfums enivrants et des couleurs éclatantes de la nature. Ce sentier offre une expérience visuelle et olfactive unique, avec des vues panoramiques sur les champs à perte de vue et une ambiance paisible qui invite à la détente et à la contemplation.", null, 8, "https://blog.ab.bluecross.ca/wp-content/uploads/2020/08/fav-hikes-part-three.jpg", null, "Champs de Fleurs en Fleur", "Promenade des Champs de Fleurs", 1, null, 7, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 33, null, "Une randonnée jusqu'à un pittoresque lac de montagne, niché au creux des sommets enneigés et entouré d'une nature sauvage et préservée. Ce sentier offre des vues panoramiques spectaculaires sur les montagnes environnantes et une atmosphère paisible et relaxante près de l'eau cristalline du lac.", null, 10, "https://www.tourismpei.com/sites/default/files/styles/hero_mobile/public/media/images/51271316495_139f7c6199_o_0.jpg?h=3cbfe8df&itok=dRMEGC9G", null, "Lac de Montagne Tranquille", "Escapade au Lac de Montagne", 1, null, 9, 0, 0, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 34, null, "Une aventure à travers les ruines anciennes d'une civilisation disparue, où vous pourrez découvrir l'histoire fascinante de ce site archéologique. Ce sentier offre une expérience immersive dans le passé, avec des vestiges bien préservés et des paysages à couper le souffle qui témoignent de la grandeur passée de cette civilisation.", null, 12, "https://i.cbc.ca/1.4170049.1530218327!/fileImage/httpImage/hiking-trails.jpg", null, "Site Archéologique des Ruines Anciennes", "Sentier des Ruines Anciennes", 1, null, 11, 0, 0, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 35, null, "Une randonnée le long de falaises côtières majestueuses, offrant des vues spectaculaires sur l'océan et les côtes rocheuses. Ce sentier offre une expérience unique en bord de mer, avec des panoramas à couper le souffle et une ambiance maritime rafraîchissante.", null, 14, "https://www.mississauga.ca/wp-content/uploads/2022/10/14143203/20221010_115918-scaled.jpg", null, "Falaises Côtières", "Randonnée des Falaises Côtières", 1, null, 13, 0, 0, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 36, null, "Une balade à travers une vallée paisible et endormie, où le temps semble s'être arrêté. Ce sentier offre une expérience tranquille en pleine nature, avec des paysages pittoresques et une ambiance relaxante qui invite à la contemplation.", null, 16, "https://www.lutsen.com/sites/default/files/styles/scale_1440/public/2021-10/Biking%20-%20Molly%20at%20Britton%20Peak%20-%20VCC%20UL%20-%20by%20Al%20%26%20Lyndsey%20Johnson%20%20%2842%29.jpg?itok=N7pFjnwx", null, "Vallée Endormie", "Sentier de la Vallée Endormie", 1, null, 15, 0, 0, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 37, null, "Une randonnée jusqu'au sommet d'un pic vertigineux, offrant des vues à couper le souffle sur les vallées et les montagnes environnantes. Ce sentier offre une expérience exaltante pour les amateurs de sensations fortes, avec des panoramas spectaculaires et une montée stimulante.", null, 18, "https://www.surrey.ca/sites/default/files/styles/metatag_facebook/public/2020-08/InvergarryNatureTrail.JPG?h=d262251e&itok=oXPbDLYW", null, "Pic Vertigineux", "Randonnée du Pic Vertigineux", 1, null, 17, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 38, null, "Une balade le long de plusieurs chutes mystiques, cachées au cœur d'une forêt luxuriante. Ce sentier offre une expérience enchantée, avec des cascades paisibles et des paysages magiques qui émerveilleront les sens.", null, 20, "https://i.pinimg.com/originals/7f/e4/e2/7fe4e24eb9024d61139ac44a607e478a.jpg", null, "Forêt des Chutes Mystiques", "Chemin des Chutes Mystiques", 1, null, 19, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 39, null, "Une randonnée jusqu'à un magnifique lac de cristal, dont les eaux claires reflètent les montagnes environnantes. Ce sentier offre une expérience rafraîchissante en plein air, avec la possibilité de se baigner dans les eaux cristallines du lac.", null, 22, "https://www.nps.gov/hosp/planyourvisit/images/_DSC7261.jpg?maxwidth=650&autorotate=false", null, "Lac de Cristal", "Randonnée du Lac de Cristal", 1, null, 21, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 40, null, "Une randonnée à travers un canyon étincelant, où la lumière du soleil se reflète sur les parois rocheuses pour créer un spectacle scintillant. Ce sentier offre une expérience visuelle saisissante, avec des jeux de lumière magiques et des formations rocheuses uniques.", null, 24, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQAO_hEyiI2Tkfl5TI78QWQpncjBZ_7VWxtU4rceThJXeSRAKCutUx62Hfw5sdbX_QBEa4&usqp=CAU", null, "Canyon Étincelant", "Sentier du Canyon Étincelant", 1, null, 23, 0, 1, null, true });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 41, null, "Une balade à travers des jardins enchanteurs, où vous pourrez admirer une grande variété de plantes exotiques et de fleurs colorées. Ce sentier offre une expérience botanique unique, avec des jardins bien entretenus et une ambiance paisible qui invite à la contemplation.", null, 26, "https://i.natgeofe.com/n/71741e7e-db92-41fc-9c54-f781c3df87df/2C57A8C_16x9.jpg", null, "Jardins Enchantés", "Promenade des Jardins Enchantés", 1, null, 25, 0, 0, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 42, null, "Une randonnée épique jusqu'au sommet d'une montagne enneigée, offrant des vues à couper le souffle sur les paysages alpins. Ce sentier offre une expérience alpine authentique, avec des vues panoramiques sur les montagnes enneigées et une ambiance hivernale magique.", null, 28, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUGLsH09jYtknRspMu0BDdOsADZrSLhzBUtA&usqp=CAU", null, "Sommet Enneigé", "Randonnée du Sommet Enneigé", 1, null, 27, 0, 0, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 43, null, "Une promenade à travers des marais brumeux, où l'air est chargé d'humidité et la lumière filtre à travers le brouillard. Ce sentier offre une expérience mystérieuse et immersive dans les marais, avec des paysages enveloppés de brume et une ambiance envoûtante.", null, 30, "https://assets.simpleviewinc.com/simpleview/image/upload/c_limit,h_1200,q_75,w_1200/v1/clients/gatlinburgtn/Forney_Ridge_trail_Smokies_3_796a5a89-db2b-49b4-9c62-b5fd805e1885.jpg", null, "Marais Brumeux", "Sentier des Marais Brumeux", 1, null, 29, 0, 0, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 45, null, "Une randonnée jusqu'à une cascade éternelle, dont les eaux coulent continuellement et offrent un spectacle apaisant. Ce sentier offre une expérience rafraîchissante en plein air, avec la possibilité de se détendre près de la cascade et d'admirer sa beauté intemporelle.", null, 32, "https://travel.home.sndimg.com/content/dam/images/travel/fullset/2012/08/24/a0/us-hiking-trails_ss_001.rend.hgtvcom.616.462.suffix/1491580965291.jpeg", null, "Cascade Éternelle", "Sentier de la Cascade Éternelle", 1, null, 31, 0, 1, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 46, null, "Une balade paisible autour d'un lac serein, où vous pourrez profiter de la tranquillité de l'eau et observer la faune locale. Ce sentier offre une expérience relaxante en plein air, avec des vues pittoresques sur le lac et une ambiance calme qui invite à la méditation.", null, 34, "https://assets.simpleviewinc.com/simpleview/image/upload/c_limit,h_1200,q_75,w_1200/v1/clients/gatlinburgtn/Forney_Ridge_trail_Smokies_3_796a5a89-db2b-49b4-9c62-b5fd805e1885.jpg", null, "Lac Serein", "Promenade du Lac Serein", 1, null, 33, 0, 1, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 47, null, "Une randonnée à travers les montagnes miroir, où les sommets reflètent parfaitement le ciel et les nuages. Ce sentier offre une expérience visuelle spectaculaire, avec des panoramas époustouflants et des paysages qui semblent sortis d'un rêve.", null, 36, "https://1.bp.blogspot.com/-PzBA1W501qQ/VBhtDjlsI7I/AAAAAAAAaRM/L4PGqyTlPtg/s1600/Aspen%2B009.JPG", null, "Montagnes Miroir", "Randonnée des Montagnes Miroir", 1, null, 35, 0, 1, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 48, null, "Une balade en fin de journée pour admirer le coucher de soleil sur l'horizon, offrant des couleurs chaudes et des reflets dorés sur l'eau. Ce sentier offre une expérience magique en plein air, avec des vues panoramiques sur le ciel coloré et une ambiance paisible qui invite à la contemplation.", null, 38, "https://media.cnn.com/api/v1/images/stellar/prod/230821123314-01-body-family-of-7-hiking-americas-longest-trails.jpg?c=original", null, "Coucher de Soleil", "Sentier du Coucher de Soleil", 1, null, 37, 0, 0, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 49, null, "Une randonnée épique à travers un canyon profond, où les parois rocheuses s'élèvent à des hauteurs vertigineuses de chaque côté. Ce sentier offre une expérience immersive dans la nature sauvage, avec des vues spectaculaires sur les falaises et les gorges.", null, 40, "https://www.vmcdn.ca/f/files/glaciermedia/import/lmp-all/899734-image-copy.jpg", null, "Canyon Profond", "Randonnée du Canyon Profond", 1, null, 39, 0, 1, null, false });

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreationDate", "Description", "Distance", "EndingCoordinatesId", "ImageUrl", "IsApproved", "Location", "Name", "OwnerId", "Rating", "StartingCoordinatesId", "TotalRatings", "Type", "UserId", "isPublic" },
                values: new object[] { 50, null, "Une balade à travers une vallée mystique, où les brumes matinales créent une atmosphère envoûtante. Ce sentier offre une expérience magique en plein air, avec des paysages enveloppés de brume et une ambiance tranquille qui invite à la contemplation.", null, 42, "https://gowanderwild.com/wp-content/uploads/2022/12/The-Garden-Wall-Shelly-Pabis.jpg", null, "Vallée des Brumes", "Sentier de la Vallée des Brumes", 1, null, 41, 0, 1, null, false });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TrailId",
                table: "Comments",
                column: "TrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_TrailId",
                table: "Coordinates",
                column: "TrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Hikes_TrailId",
                table: "Hikes",
                column: "TrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Hikes_UserId",
                table: "Hikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_UserId",
                table: "Levels",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrailImages_TrailId",
                table: "TrailImages",
                column: "TrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_EndingCoordinatesId",
                table: "Trails",
                column: "EndingCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_StartingCoordinatesId",
                table: "Trails",
                column: "StartingCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Trails_UserId",
                table: "Trails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrailUsers_IdentityUserId",
                table: "TrailUsers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteTrails_UserId",
                table: "UserFavoriteTrails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Trails_TrailId",
                table: "Comments",
                column: "TrailId",
                principalTable: "Trails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Trails_TrailId",
                table: "Coordinates",
                column: "TrailId",
                principalTable: "Trails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrailUsers_AspNetUsers_IdentityUserId",
                table: "TrailUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinates_Trails_TrailId",
                table: "Coordinates");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Hikes");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "TrailImages");

            migrationBuilder.DropTable(
                name: "UserFavoriteTrails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Trails");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "TrailUsers");
        }
    }
}
