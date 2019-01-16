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
                    AdministratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
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
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
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
                    Bio = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
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
                    IsNew = table.Column<bool>(nullable: false),
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
                    { 1, "", "", "2-legged balance (Narrow Base of Support)" },
                    { 124, "", "Don’t allow hip to ER, back foot returns slow, limit trunk sway", "Theraband Standing Hip Abduction – Around Ankles" },
                    { 125, "", "Watch for knee valgus", "Step up" },
                    { 126, "", "Watch for knee valgus", "Step down" },
                    { 127, "", "Watch for knee valgus", "Power ups" },
                    { 128, "", "", "Hurdle step over" },
                    { 129, "", "", "Lateral Hurdle step over" },
                    { 130, "", "", "Knee Extension Stretch" },
                    { 131, "", "", "Doorway Pec Stretch" },
                    { 132, "", "Towel roll between UE and trunk", "Sidelying Shoulder ER" },
                    { 123, "", "Don’t allow hip to ER, back foot returns slow, limit trunk sway", "Theraband Standing Hip Abduction – Around Ankles" },
                    { 133, "", "", "Sidelying Lat Stretch" },
                    { 135, "", "", "Standing Hamstring Stretch" },
                    { 136, "", "", "Standing Hamstring Stretch Legs Crossed" },
                    { 137, "", "", "Standing Calf Stretch with Foot Propped" },
                    { 138, "", "", "Standing Calf Stretch in Lunge Position" },
                    { 139, "", "", "Dynamic Warm Up Knee Pull" },
                    { 140, "", "", "Dynamic Warm Up Gate Opener" },
                    { 141, "", "", "Dynamic Warm Up Gate Closer" },
                    { 142, "", "", "Dynamic Warm Up Butt Kickers" },
                    { 143, "", "", "Dynamic Warm Up Quad Pull" },
                    { 134, "", "", "Standing Quad Stretch" },
                    { 144, "", "", "Dynamic Warm Up Side Lunge Alternating" },
                    { 122, "", "Don’t allow hip to ER, back foot returns slow, limit trunk sway", "Theraband Standing Hip Abduction – Around Feet" },
                    { 120, "", "", "TRX Back Row" },
                    { 100, "", "", "AROM Shoulder External Rotation" },
                    { 101, "", "Towel roll between UE and trunk", "Theraband Shoulder External Rotation (Neutral)" },
                    { 102, "", "", "Theraband Shoulder External Rotation (90/90)" },
                    { 103, "", "", "AROM Shoulder Internal Rotation" },
                    { 104, "", "Towel roll between UE and trunk", "Theraband Shoulder Internal Rotation (Neutral)" },
                    { 105, "", "", "Theraband Shoulder Internal Rotation (90/90)" },
                    { 106, "", "", "AROM Cervical Rotation" },
                    { 107, "", "", "AROM Cervical Flexion" },
                    { 108, "", "", "AROM Cervical Extension" },
                    { 121, "", "", "Latissimus Dorsi Pulldown" },
                    { 109, "", "", "Chin Tucks (Supine)" },
                    { 111, "", "", "Chin Tucks (Quadruped)" },
                    { 112, "", "", "Triceps Extension" },
                    { 113, "", "", "Theraband Shoulder Extension" },
                    { 114, "", "", "Biceps Curl" },
                    { 115, "", "", "Hammer Curl" },
                    { 116, "", "", "UE Hang" },
                    { 117, "", "", "TRX Chest Press" },
                    { 118, "", "", "Back Row" },
                    { 119, "", "", "Single Arm Back Row" },
                    { 110, "", "", "Chin Tucks (Seated)" },
                    { 145, "", "", "Dynamic Warm Up Lunge with In-step" },
                    { 146, "", "", "Dynamic Warm Up Inch Worm" },
                    { 147, "", "", "Dynamic Warm Frankenstein Walk" },
                    { 173, "", "", "Shoulder Wand Flexion" },
                    { 174, "", "", "Shoulder Wand Flexion (Supine)" },
                    { 175, "", "", "Shoulder Wand Abduction" },
                    { 176, "", "", "Shoulder Wand ER" },
                    { 177, "", "", "Shoulder Wand IR" },
                    { 178, "", "", "Shoulder Flexion Ladder" },
                    { 179, "", "", "Shoulder Flexion Table Slide" },
                    { 180, "", "", "Shoulder Pendulums" },
                    { 181, "", "", "Scapular Squeezes" },
                    { 172, "", "", "Levator Scapulae Stretch" },
                    { 182, "", "", "Wrist Flexion  - Theraband" },
                    { 184, "", "", "Wrist Extension  - Theraband" },
                    { 185, "", "", "Wrist Extension  - AROM" },
                    { 186, "", "", "Wrist Ulnar Deviation  - Theraband" },
                    { 187, "", "", "Wrist Ulnar Deviation  - AROM" },
                    { 188, "", "", "Wrist Radial Deviation   - Theraband" },
                    { 189, "", "", "Wrist Radial Deviation   - AROM" },
                    { 190, "", "", "Wrist Supination  - Theraband" },
                    { 191, "", "", "Wrist Supination  - AROM" },
                    { 192, "", "", "Wrist Pronation  - Theraband" },
                    { 183, "", "", "Wrist Flexion  - AROM" },
                    { 171, "", "", "Upper Trapezius Stretch" },
                    { 170, "", "", "Cable Triceps Press" },
                    { 169, "", "", "Cable Biceps Curl" },
                    { 148, "", "", "Dynamic Warm Monster Walk" },
                    { 149, "", "", "RDL Dumbbell" },
                    { 150, "", "", "RDL Barbell" },
                    { 151, "", "", "Exercise Ball Pelvic Tilts" },
                    { 152, "", "", "Exercise Ball Marching" },
                    { 153, "", "", "Exercise Ball Ts" },
                    { 154, "", "", "Exercise Ball Ys" },
                    { 155, "", "", "Exercise Ball Is" },
                    { 156, "", "", "TRX Ts" },
                    { 157, "", "", "TRX Ys" },
                    { 158, "", "", "TRX Is" },
                    { 159, "", "", "TRX Single Arm Row" },
                    { 160, "", "", "TRX Biceps Curl" },
                    { 161, "", "", "TRX Triceps Press" },
                    { 162, "", "", "TRX Chest Fly" },
                    { 163, "", "", "TRX Plank" },
                    { 164, "", "", "TRX Body Saw" },
                    { 165, "", "", "TRX Pike" },
                    { 166, "", "", "Cable Pallof Press" },
                    { 167, "", "", "Cable Shoulder ER" },
                    { 168, "", "", "Cable Shoulder ER 90/90" },
                    { 99, "", "", "AROM Shoulder Abduction" },
                    { 98, "", "Cue for elbows aligned with shoulder and push into wall", "Wall Slides" },
                    { 97, "", "", "Theraband Shoulder Flexion" },
                    { 96, "", "", "AROM Shoulder Flexion" },
                    { 27, "", "", "90/90 Thoracic Rotation" },
                    { 28, "", "Use tactile cueing medial/inferior to ASIS as needed for TA activation", "ASLR" },
                    { 29, "", "", "Hamstring Stretch with Rope" },
                    { 30, "", "", "Hip Adductor Stretch with Rope" },
                    { 31, "", "", "Piriformis stretch with hip flexed at 30 deg" },
                    { 32, "", "", "Piriformis stretch with hip flexed at 90 deg" },
                    { 33, "", "", "Reverse Plank" },
                    { 34, "", "Make sure that hips are stacked and leg is slightly in extension", "Sidelying Straight Leg Hip Abduction" },
                    { 35, "", "Make sure that hips are stacked", "Sidelying Hip Flexion" },
                    { 26, "", "", "90/90 Arm Swing" },
                    { 36, "", "Make sure that hips are stacked", "Sidelying Hip Extension" },
                    { 38, "", "Make sure that hips are stacked, legs are slightly bent", "Sidelying Clamshell" },
                    { 39, "", "Make sure that hips are stacked", "Sidelying Hip Bicycles (Clockwise)" },
                    { 40, "", "Make sure that hips are stacked", "Sidelying Hip Bicycles (Counterclockwise)" },
                    { 41, "", "Make sure that hips are stacked", "Sidelying Hip Circles (Clockwise)" },
                    { 42, "", "Make sure that hips are stacked", "Sidelying Hip Circles (Counterclockwise)" },
                    { 43, "", "Make sure that hips are stacked", "Side Plank – on elbow" },
                    { 44, "", "Make sure that hips are stacked", "Side Plank – on Hand" },
                    { 45, "", "Make sure that hips are stacked", "TRX Side Plank – on elbow" },
                    { 46, "", "Make sure that hips are stacked", "TRX Side Plank – on hand" },
                    { 37, "", "Make sure that hips are stacked", "Sidelying Hip Flexion - Extension" },
                    { 25, "", "", "Supine SL Knee Extension (Hamstring stretch/neuroglide)" },
                    { 24, "", "", "Pec Major Stretch on Foam Roll" },
                    { 23, "", "", "Glute Bridge" },
                    { 2, "", "", "2-legged balance (Narrow Base of Support) – Eyes Closed" },
                    { 3, "", "", "2-legged balance (Narrow Base of Support) – Bosu Ball" },
                    { 4, "", "", "2-legged balance (Narrow Base of Support) – Airex Pad" },
                    { 5, "", "", "Single leg balance" },
                    { 6, "", "", "Single leg balance – Eyes Closed" },
                    { 7, "", "", "Single leg balance – Bosu Ball" },
                    { 8, "", "", "Single leg balance – Airex Pad" },
                    { 9, "", "", "Tandem balance" },
                    { 10, "", "", "Modified tandem balance" },
                    { 11, "", "", "Tandem balance on Airex Pad" },
                    { 12, "", "Use tactile cueing medial/inferior to ASIS as needed", "Transverse Abdominus Activation" },
                    { 13, "", "Use tactile cueing medial/inferior to ASIS as needed", "Transverse Abdominus Activation with Exercise Ball" },
                    { 14, "", "Have patient place one hand on umbilicus, and other over sternum with focus on making lower hand move with breath", "Diaphragmatic Breathing" },
                    { 15, "", "", "Inner Core Marching" },
                    { 16, "", "Use tactile cueing medial/inferior to ASIS as needed", "Transverse Abdominus Activation with single leg slides alt." },
                    { 17, "", "Use tactile cueing medial/inferior to ASIS as needed", "Transverse Abdominus Activation with double leg slide" },
                    { 18, "", "Stop prior to contralateral hip rising off the table", "Lower trunk rotation" },
                    { 19, "", "Pain free range", "Single Knee to Chest" },
                    { 20, "", "", "Double Knee to Chest" },
                    { 21, "", "", "Lumbar Multifidus Activation – Contralateral SL Modified Bridge" },
                    { 22, "", "Manual resistance as needed", "Lumbar Multifidus Activation – Prone Contralateral UE Lift" },
                    { 47, "", "Make sure that hips are stacked", "Side Plank – on elbow with leg elevated" },
                    { 193, "", "", "Wrist Pronation  - AROM" },
                    { 48, "", "Put shoulder blades into back pockets", "Prone Lower Trapezius Activation" },
                    { 50, "", "Make sure that hips are stacked", "Plank – on hands" },
                    { 76, "", "", "KB 1 Arm Deadlift" },
                    { 77, "", "", "Suitcase carry" },
                    { 78, "", "", "Overhead carry" },
                    { 79, "", "", "Glute Sets" },
                    { 80, "", "", "Quad sets" },
                    { 81, "", "", "Heel slides" },
                    { 82, "", "", "Wall Slides UE" },
                    { 83, "", "", "Wall Slides LE" },
                    { 84, "", "", "Seated Knee Flexion" },
                    { 75, "", "", "KB Figure 8" },
                    { 85, "", "", "Supine Hip Abduction" },
                    { 87, "", "", "SAQ" },
                    { 88, "", "", "AROM Dorsiflexion" },
                    { 89, "", "", "Theraband Dorsiflexion" },
                    { 90, "", "", "AROM Plantarflexion" },
                    { 91, "", "", "Theraband Plantarflexion" },
                    { 92, "", "", "AROM Eversion - Ankle" },
                    { 93, "", "", "Theraband Eversion - Ankle" },
                    { 94, "", "", "AROM Inversion - Ankle" },
                    { 95, "", "", "Theraband Inversion - Ankle" },
                    { 86, "", "", "LAQ" },
                    { 74, "", "", "KB Windmill" },
                    { 73, "", "", "KB Swing – 1 arm" },
                    { 72, "", "", "KB Swing – 2 arm" },
                    { 51, "", "Make sure that hips are stacked", "Modified Plank – on hands" },
                    { 52, "", "", "Prone Superman Lift" },
                    { 53, "", "", "Prone UE lift and contralateral LE lift" },
                    { 54, "", "", "Prone Knee Flexion" },
                    { 55, "", "", "Prone Knee Extension Hang" },
                    { 56, "", "", "Prone Lumbar Extension – on elbows" },
                    { 57, "", "", "Prone Lunbar Extension – on hands" },
                    { 58, "", "", "Prone Lumbar Extension Press Ups" },
                    { 59, "", "", "Quadruped Thoracic Rotation" },
                    { 60, "", "", "Quadruped Bent Knee Hip Abduction" },
                    { 61, "", "", "Quadruped Hip Extension – Straight Leg" },
                    { 62, "", "", "Quadruped Hip Extension – Bent Leg" },
                    { 63, "", "", "Quadruped Bird Dog" },
                    { 64, "", "", "Quadruped Cat/Cows" },
                    { 65, "", "", "Quadruped Hip Rocking – Hips Externally Rotated" },
                    { 66, "", "", "Quadruped Hip Rocking – Hips Internally Rotated" },
                    { 67, "", "", "Kneeling Chop with Theraband" },
                    { 68, "", "Back leg elevated", "Kneeling Super Quad Stretch" },
                    { 69, "", "", "Sit to Stand" },
                    { 70, "", "", "Squats" },
                    { 71, "", "", "Lunge" },
                    { 49, "", "Make sure that hips are stacked", "Plank – on elbows" }
                });

            migrationBuilder.InsertData(
                table: "Therapists",
                columns: new[] { "TherapistId", "AccountType", "Bio", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "Username" },
                values: new object[] { 1, 0, "New Dr.", new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), "Test@email.com", "DR.", "Doctor", "911", "TygerHugh" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AccountType", "Bio", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "TherapistId", "Username" },
                values: new object[] { 1, 2, "bad back", new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), "one@email.com", "Hung", "thats-me", "911", 1, "Alex" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AccountType", "Bio", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "TherapistId", "Username" },
                values: new object[] { 2, 2, "bad knees", new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), "two@email.com", "Also Hung", "2nd", "1800", 1, "Hung" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AccountType", "Bio", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber", "TherapistId", "Username" },
                values: new object[] { 3, 2, "accident prone", new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), "three@email.com", "Sike", "Still-Hung", "411", 1, "Tyger" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_Username",
                table: "Administrators",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_Username",
                table: "Credentials",
                column: "Username",
                unique: true);

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
                name: "IX_Patients_Username",
                table: "Patients",
                column: "Username",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_Username",
                table: "Therapists",
                column: "Username",
                unique: true);
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
