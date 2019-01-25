using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class SeedCredentialTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "CredentialId", "AccountType", "Password", "Username" },
                values: new object[,]
                {
                    { 1, 0, "admin", "TygerHugh" },
                    { 2, 1, "password", "Alex" },
                    { 3, 2, "abc", "hung" }
                });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "CredentialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "CredentialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "CredentialId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 23, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
