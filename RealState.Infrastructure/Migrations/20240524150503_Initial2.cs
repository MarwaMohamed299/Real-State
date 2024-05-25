using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealState.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Admin_AdminId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Auditors_AuditorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Surveyers_SurveyerId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "RequestId1",
                table: "Appartments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequestLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestLog_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "FName", "LName", "Nationality", "SSN", "UserId" },
                values: new object[] { 32, "Sandy", "Doe", 0, 0, "1381877e-4124-4662-b3cc-7ed2a9176fe4" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4141ecc6-1af5-4823-8065-a6b9a6dfb65d", null, "Auditor", "AUDITOR" },
                    { "559c9cc2-42cc-4df9-a6b6-4f7f0901a219", null, "Surveyer", "SURVEYER" },
                    { "a156dfdd-3a37-4e02-90ad-f8697ccbc506", null, "Admin", "ADMIN" },
                    { "bef7a958-2903-403a-911d-641cac1b2cd8", null, "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", 0, "54f366c3-8489-46e1-9b1d-44d8bd5558c3", null, false, false, null, null, null, null, null, false, "896e272a-222e-4942-a9fa-5960a7fa4dce", false, "Sara" },
                    { "1381877e-4124-4662-b3cc-7ed2a9176fe4", 0, "14382ec1-8d00-44a0-9636-c7cca36e74e8", null, false, false, null, null, null, null, null, false, "bdd53c78-9bff-4716-a0bd-b25054a583d0", false, "Jakson" },
                    { "1b8e4523-e299-42b7-aeeb-fd4577402407", 0, "f6027720-326e-4c00-bcfd-684c484e7f11", null, false, false, null, null, null, null, null, false, "28bbd33e-cd67-4854-b14f-e2be4b00b867", false, "John" },
                    { "49d53bf1-d7fc-4719-a047-9335b8ef9fda", 0, "398b57a7-272f-41ea-abfe-6861f71854e8", null, false, false, null, null, null, null, null, false, "99555b41-4b86-4690-96b9-282fe849ea5b", false, "Michael" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "FName", "LName", "Nationality", "SSN", "UserId" },
                values: new object[] { 102, "John", "Doe", 0, "123-45-6789", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Company1" });

            migrationBuilder.InsertData(
                table: "Auditors",
                columns: new[] { "Id", "CompanyId", "FName", "LName", "Nationality", "SSN", "UserId" },
                values: new object[] { 5, 1, "Jackley", "Doe", 0, 0, "1b8e4523-e299-42b7-aeeb-fd4577402407" });

            migrationBuilder.InsertData(
                table: "Surveyers",
                columns: new[] { "Id", "CompanyId", "FName", "LName", "Nationality", "SSN", "UserId" },
                values: new object[] { 1, 1, "Suzan", "Doe", 0, 0, "49d53bf1-d7fc-4719-a047-9335b8ef9fda" });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "AdminId", "AppartmentArea", "Area", "AuditorId", "Building", "CityId", "ClientId", "CreatedAt", "District", "Fees", "FloorCount", "OwnerAddress", "PhoneNumber", "Street", "SurveyerId", "UnitNumber", "UnitTypeId", "X", "Y" },
                values: new object[] { 1, 32, null, 100m, 5, "Royal Tower", 1, 102, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4766), "Zamalek", null, 5, "123 Main St", "1234567890", "Nile St", 1, "A101", null, 30.12345f, 31.98765f });

            migrationBuilder.InsertData(
                table: "RequestLog",
                columns: new[] { "Id", "CreationDate", "RequestId", "Status", "UserId", "UserType" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4783), 1, "Pending", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 2, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4788), 1, "New", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 3, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4791), 1, "Paid", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 4, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4794), 1, "Assigned To Company", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 5, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4797), 1, "Assigned To Surveyer", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 6, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4803), 1, "AppointMent Arrangement", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 7, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4806), 1, "Pending For Company Review", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 8, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4809), 1, "Pending For User Data Completion", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 9, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4812), 1, "Pending For Surveyer Completion", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 10, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4816), 1, "Cancelled By User", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 11, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4819), 1, "Completed", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" },
                    { 12, new DateTime(2024, 5, 24, 18, 5, 0, 720, DateTimeKind.Local).AddTicks(4823), 1, "Pendingfor Authority Review", "0d3dea4c-2c77-4d00-b497-3c670cf8c40c", "Client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appartments_RequestId1",
                table: "Appartments",
                column: "RequestId1",
                unique: true,
                filter: "[RequestId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLog_RequestId",
                table: "RequestLog",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartments_Requests_RequestId1",
                table: "Appartments",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Admin_AdminId",
                table: "Requests",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Auditors_AuditorId",
                table: "Requests",
                column: "AuditorId",
                principalTable: "Auditors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Surveyers_SurveyerId",
                table: "Requests",
                column: "SurveyerId",
                principalTable: "Surveyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartments_Requests_RequestId1",
                table: "Appartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Admin_AdminId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Auditors_AuditorId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Surveyers_SurveyerId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "RequestLog");

            migrationBuilder.DropIndex(
                name: "IX_Appartments_RequestId1",
                table: "Appartments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4141ecc6-1af5-4823-8065-a6b9a6dfb65d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "559c9cc2-42cc-4df9-a6b6-4f7f0901a219");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a156dfdd-3a37-4e02-90ad-f8697ccbc506");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bef7a958-2903-403a-911d-641cac1b2cd8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d3dea4c-2c77-4d00-b497-3c670cf8c40c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1381877e-4124-4662-b3cc-7ed2a9176fe4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b8e4523-e299-42b7-aeeb-fd4577402407");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49d53bf1-d7fc-4719-a047-9335b8ef9fda");

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Auditors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Surveyers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RequestId1",
                table: "Appartments");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Admin_AdminId",
                table: "Requests",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Auditors_AuditorId",
                table: "Requests",
                column: "AuditorId",
                principalTable: "Auditors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Clients_ClientId",
                table: "Requests",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Surveyers_SurveyerId",
                table: "Requests",
                column: "SurveyerId",
                principalTable: "Surveyers",
                principalColumn: "Id");
        }
    }
}
