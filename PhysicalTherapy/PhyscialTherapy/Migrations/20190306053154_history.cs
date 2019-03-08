using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class history : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompleteReps",
                table: "RoutineExercises",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 3, 5, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteReps",
                table: "RoutineExercises");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 12, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
