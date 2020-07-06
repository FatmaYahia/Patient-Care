using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PatientCare.DAL.Migrations
{
    public partial class jjjjj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewd",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 607, DateTimeKind.Unspecified).AddTicks(9367), new DateTime(2020, 6, 21, 18, 27, 48, 609, DateTimeKind.Unspecified).AddTicks(8196) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 609, DateTimeKind.Unspecified).AddTicks(9279), new DateTime(2020, 6, 21, 18, 27, 48, 609, DateTimeKind.Unspecified).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 609, DateTimeKind.Unspecified).AddTicks(9323), new DateTime(2020, 6, 21, 18, 27, 48, 609, DateTimeKind.Unspecified).AddTicks(9328) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(2591), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3030), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3058), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3063) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3067), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5688), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5705) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6101), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6118) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6130), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6139), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6148), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3634), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(4060), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(4077) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(4096), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(1505), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(1972), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(1989) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(4649), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(4667) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5066), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5083) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5095), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5104), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5108) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5112), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5116) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5121), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5125) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5129), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5137), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6770), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(6789), "sssr2439uh" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 612, DateTimeKind.Unspecified).AddTicks(3390), new DateTime(2020, 6, 21, 18, 27, 48, 612, DateTimeKind.Unspecified).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 612, DateTimeKind.Unspecified).AddTicks(4534), new DateTime(2020, 6, 21, 18, 27, 48, 612, DateTimeKind.Unspecified).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 612, DateTimeKind.Unspecified).AddTicks(4601), new DateTime(2020, 6, 21, 18, 27, 48, 612, DateTimeKind.Unspecified).AddTicks(4606) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(224), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(799), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(820) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(833), new DateTime(2020, 6, 21, 18, 27, 48, 611, DateTimeKind.Unspecified).AddTicks(873) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsViewd",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 262, DateTimeKind.Unspecified).AddTicks(7622), new DateTime(2020, 6, 20, 2, 6, 38, 264, DateTimeKind.Unspecified).AddTicks(8142) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 264, DateTimeKind.Unspecified).AddTicks(9207), new DateTime(2020, 6, 20, 2, 6, 38, 264, DateTimeKind.Unspecified).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 264, DateTimeKind.Unspecified).AddTicks(9251), new DateTime(2020, 6, 20, 2, 6, 38, 264, DateTimeKind.Unspecified).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(2615), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3048), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3065) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3078), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3087), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3091) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5833), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5850) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6245), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6274), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6284), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6288) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6293), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6297) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3751), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3769) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4179), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4215), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(1539), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(1558) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(1996), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(2014) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4773), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5187), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5204) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5216), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5221) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5225), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5229) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5234), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5238) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5243), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5247) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5251), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5255) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5259), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6905), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(6924), "xooa9473yq" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 267, DateTimeKind.Unspecified).AddTicks(3588), new DateTime(2020, 6, 20, 2, 6, 38, 267, DateTimeKind.Unspecified).AddTicks(3616) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 267, DateTimeKind.Unspecified).AddTicks(4715), new DateTime(2020, 6, 20, 2, 6, 38, 267, DateTimeKind.Unspecified).AddTicks(4736) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 267, DateTimeKind.Unspecified).AddTicks(4771), new DateTime(2020, 6, 20, 2, 6, 38, 267, DateTimeKind.Unspecified).AddTicks(4776) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(309), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(339) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(813), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(831) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(844), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(849) });
        }
    }
}
