using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class ExerciseTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercises_Excercises_ExerciseId",
                table: "RoutineExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Excercises",
                table: "Excercises");

            migrationBuilder.RenameTable(
                name: "Excercises",
                newName: "Exercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "ExerciseId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercises_Exercises_ExerciseId",
                table: "RoutineExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutineExercises_Exercises_ExerciseId",
                table: "RoutineExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Excercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Excercises",
                table: "Excercises",
                column: "ExerciseId");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Therapists",
                keyColumn: "TherapistId",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_RoutineExercises_Excercises_ExerciseId",
                table: "RoutineExercises",
                column: "ExerciseId",
                principalTable: "Excercises",
                principalColumn: "ExerciseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
