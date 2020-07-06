using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PatientCare.DAL.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessLevel",
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
                    table.PrimaryKey("PK_AccessLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodTypes",
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
                    table.PrimaryKey("PK_BloodTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoronaStatuses",
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
                    table.PrimaryKey("PK_CoronaStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonateTypes",
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
                    table.PrimaryKey("PK_DonateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
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
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    AvailableBeds = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
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
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    JopTitle = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemView",
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
                    table.PrimaryKey("PK_SystemView", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Fk_Gender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    IsPregnant = table.Column<bool>(nullable: false),
                    CronicDiseases = table.Column<string>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    Fk_BloodType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_BloodTypes_Fk_BloodType",
                        column: x => x.Fk_BloodType,
                        principalTable: "BloodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_Fk_Gender",
                        column: x => x.Fk_Gender,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Fk_Gender = table.Column<int>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    Fk_Specialization = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Genders_Fk_Gender",
                        column: x => x.Fk_Gender,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_Fk_Specialization",
                        column: x => x.Fk_Specialization,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserPermission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_AccessLevel = table.Column<int>(nullable: false),
                    Fk_SystemUser = table.Column<int>(nullable: false),
                    Fk_SystemView = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_AccessLevel_Fk_AccessLevel",
                        column: x => x.Fk_AccessLevel,
                        principalTable: "AccessLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_SystemUser_Fk_SystemUser",
                        column: x => x.Fk_SystemUser,
                        principalTable: "SystemUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_SystemView_Fk_SystemView",
                        column: x => x.Fk_SystemView,
                        principalTable: "SystemView",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Patient = table.Column<int>(nullable: false),
                    Fk_DonateType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_DonateTypes_Fk_DonateType",
                        column: x => x.Fk_DonateType,
                        principalTable: "DonateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_Patients_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfflineCoronaTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Patient = table.Column<int>(nullable: false),
                    Fk_CoronaStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfflineCoronaTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfflineCoronaTests_CoronaStatuses_Fk_CoronaStatus",
                        column: x => x.Fk_CoronaStatus,
                        principalTable: "CoronaStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfflineCoronaTests_Patients_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnlineCoronaTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Patient = table.Column<int>(nullable: false),
                    Fk_CoronaStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCoronaTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineCoronaTests_CoronaStatuses_Fk_CoronaStatus",
                        column: x => x.Fk_CoronaStatus,
                        principalTable: "CoronaStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineCoronaTests_Patients_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Patient = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDocuments_Patients_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Doctor = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TimeFrom = table.Column<TimeSpan>(nullable: false),
                    TimeTo = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Doctors_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Doctor = table.Column<int>(nullable: false),
                    Fk_Patient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Doctors_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Patients_Fk_Patient",
                        column: x => x.Fk_Patient,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Doctor = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorDocuments_Doctors_Fk_Doctor",
                        column: x => x.Fk_Doctor,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Fk_Chat = table.Column<int>(nullable: false),
                    MessageContent = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_Fk_Chat",
                        column: x => x.Fk_Chat,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessLevel",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 11, 20, 23, 7, 107, DateTimeKind.Unspecified).AddTicks(6206), new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(4962), "FullAccess" },
                    { 2, new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7225), new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7498), "ControlAccess" },
                    { 3, new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7712), new DateTime(2020, 6, 11, 20, 23, 7, 113, DateTimeKind.Unspecified).AddTicks(7757), "ViewAccess" }
                });

            migrationBuilder.InsertData(
                table: "CoronaStatuses",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(5761), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(5802), "Positive" },
                    { 2, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6509), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6536), "Negative" },
                    { 3, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6556), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6564), "Low" },
                    { 4, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6571), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6579), "Moderate" },
                    { 5, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6586), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(6593), "Severe" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(3705), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(3734), "Male" },
                    { 2, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(4494), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(4544), "Female" }
                });

            migrationBuilder.InsertData(
                table: "SystemUser",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "JopTitle", "LastModifiedAt", "Password" },
                values: new object[] { 1, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(7738), "Developer@App.com", "Developer", true, "Developer", new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(7778), "ygag8333aw" });

            migrationBuilder.InsertData(
                table: "SystemView",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(938), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(1030), "Home" },
                    { 2, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2216), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2266), "SystemView" },
                    { 3, new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2294), new DateTime(2020, 6, 11, 20, 23, 7, 116, DateTimeKind.Unspecified).AddTicks(2303), "SystemUser" }
                });

            migrationBuilder.InsertData(
                table: "SystemUserPermission",
                columns: new[] { "Id", "CreatedAt", "Fk_AccessLevel", "Fk_SystemUser", "Fk_SystemView", "LastModifiedAt" },
                values: new object[] { 1, new DateTime(2020, 6, 11, 20, 23, 7, 118, DateTimeKind.Unspecified).AddTicks(9857), 1, 1, 1, new DateTime(2020, 6, 11, 20, 23, 7, 118, DateTimeKind.Unspecified).AddTicks(9980) });

            migrationBuilder.InsertData(
                table: "SystemUserPermission",
                columns: new[] { "Id", "CreatedAt", "Fk_AccessLevel", "Fk_SystemUser", "Fk_SystemView", "LastModifiedAt" },
                values: new object[] { 2, new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2615), 1, 1, 2, new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2674) });

            migrationBuilder.InsertData(
                table: "SystemUserPermission",
                columns: new[] { "Id", "CreatedAt", "Fk_AccessLevel", "Fk_SystemUser", "Fk_SystemView", "LastModifiedAt" },
                values: new object[] { 3, new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2732), 1, 1, 3, new DateTime(2020, 6, 11, 20, 23, 7, 119, DateTimeKind.Unspecified).AddTicks(2741) });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_Fk_Doctor",
                table: "Agendas",
                column: "Fk_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Fk_Doctor",
                table: "Chats",
                column: "Fk_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_Fk_Patient",
                table: "Chats",
                column: "Fk_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDocuments_Fk_Doctor",
                table: "DoctorDocuments",
                column: "Fk_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Fk_Gender",
                table: "Doctors",
                column: "Fk_Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Fk_Specialization",
                table: "Doctors",
                column: "Fk_Specialization");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_Fk_DonateType",
                table: "Donations",
                column: "Fk_DonateType");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_Fk_Patient",
                table: "Donations",
                column: "Fk_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Fk_Chat",
                table: "Messages",
                column: "Fk_Chat");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineCoronaTests_Fk_CoronaStatus",
                table: "OfflineCoronaTests",
                column: "Fk_CoronaStatus");

            migrationBuilder.CreateIndex(
                name: "IX_OfflineCoronaTests_Fk_Patient",
                table: "OfflineCoronaTests",
                column: "Fk_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineCoronaTests_Fk_CoronaStatus",
                table: "OnlineCoronaTests",
                column: "Fk_CoronaStatus");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineCoronaTests_Fk_Patient",
                table: "OnlineCoronaTests",
                column: "Fk_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDocuments_Fk_Patient",
                table: "PatientDocuments",
                column: "Fk_Patient");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Fk_BloodType",
                table: "Patients",
                column: "Fk_BloodType");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Fk_Gender",
                table: "Patients",
                column: "Fk_Gender");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_AccessLevel",
                table: "SystemUserPermission",
                column: "Fk_AccessLevel");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_SystemUser",
                table: "SystemUserPermission",
                column: "Fk_SystemUser");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Fk_SystemView",
                table: "SystemUserPermission",
                column: "Fk_SystemView");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "DoctorDocuments");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OfflineCoronaTests");

            migrationBuilder.DropTable(
                name: "OnlineCoronaTests");

            migrationBuilder.DropTable(
                name: "PatientDocuments");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "SystemUserPermission");

            migrationBuilder.DropTable(
                name: "DonateTypes");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "CoronaStatuses");

            migrationBuilder.DropTable(
                name: "AccessLevel");

            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "SystemView");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "BloodTypes");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
