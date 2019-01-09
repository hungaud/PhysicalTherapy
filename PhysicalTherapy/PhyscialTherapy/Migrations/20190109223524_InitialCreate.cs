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
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
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
                    ExcerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => x.ExcerciseId);
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
                name: "Administrations",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false),
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrations", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_Administrations_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TherapistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.TherapistId);
                    table.ForeignKey(
                        name: "FK_Therapists_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TherapistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId",
                        onDelete: ReferentialAction.Cascade);
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
                    PatientId = table.Column<int>(nullable: false),
                    RoutineId = table.Column<int>(nullable: false),
                    TherapistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLogs", x => x.MessageLogId);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "RoutineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageLogs_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "TherapistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineExercises",
                columns: table => new
                {
                    ExcersiseExcerciseId = table.Column<int>(nullable: true),
                    ExerciseId = table.Column<string>(nullable: true),
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
                        name: "FK_RoutineExercises_Excercises_ExcersiseExcerciseId",
                        column: x => x.ExcersiseExcerciseId,
                        principalTable: "Excercises",
                        principalColumn: "ExcerciseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutineExercises_Routines_RoutineId",
                        column: x => x.RoutineId,
                        principalTable: "Routines",
                        principalColumn: "RoutineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrations_AccountTypeId",
                table: "Administrations",
                column: "AccountTypeId");

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
                name: "IX_Patients_AccountTypeId",
                table: "Patients",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TherapistId",
                table: "Patients",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineExercises_ExcersiseExcerciseId",
                table: "RoutineExercises",
                column: "ExcersiseExcerciseId");

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
                column: "PostRoutineSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_AccountTypeId",
                table: "Therapists",
                column: "AccountTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrations");

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

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
