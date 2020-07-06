using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PatientCare.DAL.Migrations
{
    public partial class dmsdkksm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Specializations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fk_City",
                table: "Pharmacies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Fk_BloodType",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Fk_City",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Doctors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "BloodTypes",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(2615), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(2633), "A" },
                    { 2, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3048), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3065), "B" },
                    { 4, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3087), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3091), "AB" },
                    { 3, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3078), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3082), "O" }
                });

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

            migrationBuilder.InsertData(
                table: "DonateTypes",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3751), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(3769), "BloodCells" },
                    { 2, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4179), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4197), "Platelets" },
                    { 3, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4215), new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4220), "Plasma" }
                });

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

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "CreatedAt", "ImgUrl", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4773), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(4791), "Cardiology" },
                    { 5, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5234), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5238), "Nephrology" },
                    { 6, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5243), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5247), "Pediatrics" },
                    { 2, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5187), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5204), "Nutrition" },
                    { 3, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5216), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5221), "Psychiatry" },
                    { 4, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5225), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5229), "Pulmonologist" },
                    { 8, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5259), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5263), "Deratology" },
                    { 7, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5251), null, new DateTime(2020, 6, 20, 2, 6, 38, 266, DateTimeKind.Unspecified).AddTicks(5255), "Internal Medicine" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_Fk_City",
                table: "Pharmacies",
                column: "Fk_City");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Fk_City",
                table: "Hospitals",
                column: "Fk_City");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Cities_Fk_City",
                table: "Hospitals",
                column: "Fk_City",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients",
                column: "Fk_BloodType",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Cities_Fk_City",
                table: "Pharmacies",
                column: "Fk_City",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Cities_Fk_City",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Cities_Fk_City",
                table: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_Fk_City",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_Fk_City",
                table: "Hospitals");

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BloodTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DonateTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "Fk_City",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Fk_City",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "Fk_BloodType",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 107, DateTimeKind.Unspecified).AddTicks(6206), new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(4962) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7225), new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7498) });

            migrationBuilder.UpdateData(
                table: "AccessLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7712), new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(5761), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(5802) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6509), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6536) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6556), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6564) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6571), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "CoronaStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6586), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6593) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(3705), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(4494), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(4544) });

            migrationBuilder.UpdateData(
                table: "SystemUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt", "Password" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(7738), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(7778), "ygag8333aw" });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 118, DateTimeKind.Unspecified).AddTicks(9857), new DateTime(2020, 6, 11, 20, 23, 7, 118, DateTimeKind.Unspecified).AddTicks(9980) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2615), new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2674) });

            migrationBuilder.UpdateData(
                table: "SystemUserPermission",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2732), new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2741) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(938), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(1030) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2216), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2266) });

            migrationBuilder.UpdateData(
                table: "SystemView",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2294), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2303) });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_BloodTypes_Fk_BloodType",
                table: "Patients",
                column: "Fk_BloodType",
                principalTable: "BloodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
