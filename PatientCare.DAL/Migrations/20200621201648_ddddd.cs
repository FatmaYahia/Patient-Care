using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PatientCare.DAL.Migrations
{
    public partial class ddddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "Fk_BloodType",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 967, DateTimeKind.Unspecified).AddTicks(7431), new DateTime(2020, 6, 21, 22, 16, 47, 969, DateTimeKind.Unspecified).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 970, DateTimeKind.Unspecified).AddTicks(444), new DateTime(2020, 6, 21, 22, 16, 47, 970, DateTimeKind.Unspecified).AddTicks(472) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 970, DateTimeKind.Unspecified).AddTicks(491), new DateTime(2020, 6, 21, 22, 16, 47, 970, DateTimeKind.Unspecified).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(4836), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(4857) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5306), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5325) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5338), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5343) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5348), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5352) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5357), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5362) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5366), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5371) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5376), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5385), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8262), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8710), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8730) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8743), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8753), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8762), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(8767) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(6000), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(6455), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(6475) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(6494), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(3668), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(3689) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(4162), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7081), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7101) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7530), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7603), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7609) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7614), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7618) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7623), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7627) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7632), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7636) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7641), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7650), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(7654) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(9488), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(9509), "fupd2834dt" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 972, DateTimeKind.Unspecified).AddTicks(6907), new DateTime(2020, 6, 21, 22, 16, 47, 972, DateTimeKind.Unspecified).AddTicks(6943) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 972, DateTimeKind.Unspecified).AddTicks(8132), new DateTime(2020, 6, 21, 22, 16, 47, 972, DateTimeKind.Unspecified).AddTicks(8156) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 972, DateTimeKind.Unspecified).AddTicks(8206), new DateTime(2020, 6, 21, 22, 16, 47, 972, DateTimeKind.Unspecified).AddTicks(8212) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(2421), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(2455) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(2974), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(2994) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(3008), new DateTime(2020, 6, 21, 22, 16, 47, 971, DateTimeKind.Unspecified).AddTicks(3013) });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients",
                column: "Fk_BloodType",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "Fk_BloodType",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 372, DateTimeKind.Unspecified).AddTicks(8749), new DateTime(2020, 6, 21, 22, 0, 15, 375, DateTimeKind.Unspecified).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 375, DateTimeKind.Unspecified).AddTicks(3517), new DateTime(2020, 6, 21, 22, 0, 15, 375, DateTimeKind.Unspecified).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 375, DateTimeKind.Unspecified).AddTicks(3571), new DateTime(2020, 6, 21, 22, 0, 15, 375, DateTimeKind.Unspecified).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(9850), new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(417), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(439) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(453), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(463), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(468) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(473), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(477) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(483), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(488) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(493), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(498) });

            migrationBuilder.UpdateData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(503), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(507) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(4799), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(4836) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5594), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5628) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5691), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5704) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5714), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5726) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5737), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(5747) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(1208), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(1707), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(1727) });

            migrationBuilder.UpdateData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(1749), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(1754) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(8400), new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(8421) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(8932), new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(2637), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3538), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3581) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3617), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3643), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3658), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3664) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3673), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3687), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3695) });

            migrationBuilder.UpdateData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3703), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(6794), new DateTime(2020, 6, 21, 22, 0, 15, 377, DateTimeKind.Unspecified).AddTicks(6826), "zlmu3307rk" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 378, DateTimeKind.Unspecified).AddTicks(8534), new DateTime(2020, 6, 21, 22, 0, 15, 378, DateTimeKind.Unspecified).AddTicks(8569) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 378, DateTimeKind.Unspecified).AddTicks(9858), new DateTime(2020, 6, 21, 22, 0, 15, 378, DateTimeKind.Unspecified).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 378, DateTimeKind.Unspecified).AddTicks(9936), new DateTime(2020, 6, 21, 22, 0, 15, 378, DateTimeKind.Unspecified).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(7031), new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(7078) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(7643), new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(7666) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(7681), new DateTime(2020, 6, 21, 22, 0, 15, 376, DateTimeKind.Unspecified).AddTicks(7687) });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients",
                column: "Fk_BloodType",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
