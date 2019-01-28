using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class AddDateRoutine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Routines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "CredentialId",
                keyValue: 2,
                column: "AccountType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "Username",
                value: "hung");

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Routines");

            migrationBuilder.UpdateData(
                table: "Credentials",
                keyColumn: "CredentialId",
                keyValue: 2,
                column: "AccountType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "Username",
                value: "Hung");
        }
    }
}
