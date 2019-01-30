using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class AddDatePostRoutineSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PostRoutineSurveys",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "PostRoutineSurveys");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));

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

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
