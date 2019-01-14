using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhysicalTherapy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AccountType = table.Column<int>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    AccountType = table.Column<int>(nullable: false),
                    CredentialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.CredentialId);
                });

            migrationBuilder.CreateTable(
                name: "Excercises",
                columns: table => new
                {
                    Area = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "PostRoutineSurveys",
                columns: table => new
                {
                    Completed = table.Column<bool>(nullable: false),
                    LevelOfDifficulty = table.Column<int>(nullable: false),
                    LevelOfPain = table.Column<int>(nullable: false),
                    LevelOfTiredness = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PostRoutineSurveyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostRoutineSurveys", x => x.PostRoutineSurveyId);
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    AccountType = table.Column<int>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TherapistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.TherapistId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    AccountType = table.Column<int>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TherapistId = table.Column<int>(nullable: true),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routines",
                columns: table => new
                {
                    Description = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    isNew = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    RoutineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostRoutineSurveyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routines", x => x.RoutineId);
                    table.ForeignKey(
                        name: "FK_Routines_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routines_PostRoutineSurveys_PostRoutineSurveyId",
                        column: x => x.PostRoutineSurveyId,
                        principalTable: "PostRoutineSurveys",
                        principalColumn: "PostRoutineSurveyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageLogs",
                columns: table => new
                {
                    InsertDate = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    MessageLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: true),
                    RoutineId = table.Column<int>(nullable: true),
                    TherapistId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLogs", x => x.MessageLogId);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "RoutineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false),
                    HoldLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FrequencyPerDay = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Rep = table.Column<int>(nullable: true),
                    RoutineExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoutineId = table.Column<int>(nullable: false),
                    Sets = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineExercises", x => x.RoutineExerciseId);
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Excercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Excercises",
                        principalColumn: "ExerciseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "RoutineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "ExerciseId", "Area", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Knee", "", "Quad Sets" },
                    { 2, "Knee", "", "Knee Slides with Towel" },
                    { 3, "Knee", "", "Prone Knee Hang" },
                    { 4, "Knee", "", "Step Knee Flexion" },
                    { 5, "Knee", "", "Calf Stretch" },
                    { 6, "Knee", "", "Hamstring Stretch" },
                    { 7, "Knee", "", "Ice to Knee with Elevation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_PatientId",
                table: "MessageLogs",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_RoutineId",
                table: "MessageLogs",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageLogs_TherapistId",
                table: "MessageLogs",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TherapistId",
                table: "Patients",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_ExerciseId",
                table: "RoutineExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_RoutineId",
                table: "RoutineExercises",
                column: "RoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routines_PatientId",
                table: "Routines",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Routines_PostRoutineSurveyId",
                table: "Routines",
                column: "PostRoutineSurveyId",
                unique: true,
                filter: "[PostRoutineSurveyId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "MessageLogs");

            migrationBuilder.DropTable(
                name: "RoutineExercises");

            migrationBuilder.DropTable(
                name: "Excercises");

            migrationBuilder.DropTable(
                name: "Routines");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PostRoutineSurveys");

            migrationBuilder.DropTable(
                name: "Therapists");
        }
    }
}
