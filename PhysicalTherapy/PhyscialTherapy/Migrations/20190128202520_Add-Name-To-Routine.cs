using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class AddNameToRoutine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Routines",
                nullable: true);

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
                column: "Name",
                value: "Routine number 1");

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 2,
                column: "Name",
                value: "Routine number 2");

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 3,
                column: "Name",
                value: "Routine number 3");

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 1, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Routines");

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
    }
}
