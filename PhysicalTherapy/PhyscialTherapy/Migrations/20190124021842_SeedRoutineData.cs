using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class SeedRoutineData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoutineExercises",
                keyColumn: "RoutineExerciseId",
                keyValue: 3,
                column: "HoldLength",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoutineExercises",
                keyColumn: "RoutineExerciseId",
                keyValue: 6,
                column: "HoldLength",
                value: null);

            migrationBuilder.UpdateData(
                table: "RoutineExercises",
                keyColumn: "RoutineExerciseId",
                keyValue: 9,
                columns: new[] { "HoldLength", "Notes" },
                values: new object[] { null, "3rd routine holding for 30 seconds" });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "IsNew",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoutineExercises",
                keyColumn: "RoutineExerciseId",
                keyValue: 3,
                column: "HoldLength",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "RoutineExercises",
                keyColumn: "RoutineExerciseId",
                keyValue: 6,
                column: "HoldLength",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "RoutineExercises",
                keyColumn: "RoutineExerciseId",
                keyValue: 9,
                columns: new[] { "HoldLength", "Notes" },
                values: new object[] { 30m, "3rd routineholding for 30 seconds" });

            migrationBuilder.UpdateData(
                table: "Routines",
                keyColumn: "RoutineId",
                keyValue: 1,
                column: "IsNew",
                value: true);
        }
    }
}
