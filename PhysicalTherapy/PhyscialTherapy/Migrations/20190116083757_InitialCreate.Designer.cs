﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhysicalTherapy.Models;

namespace PhysicalTherapy.Migrations
{
    [DbContext(typeof(PhysicalTherapyContext))]
    [Migration("20190116083757_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhysicalTherapy.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType");

                    b.Property<string>("Bio");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("AdministratorId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Credential", b =>
                {
                    b.Property<int>("CredentialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("CredentialId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ExerciseId");

                    b.ToTable("Excercises");

                    b.HasData(
                        new { ExerciseId = 1, Area = "", Description = "", Name = "2-legged balance (Narrow Base of Support)" },
                        new { ExerciseId = 2, Area = "", Description = "", Name = "2-legged balance (Narrow Base of Support) – Eyes Closed" },
                        new { ExerciseId = 3, Area = "", Description = "", Name = "2-legged balance (Narrow Base of Support) – Bosu Ball" },
                        new { ExerciseId = 4, Area = "", Description = "", Name = "2-legged balance (Narrow Base of Support) – Airex Pad" },
                        new { ExerciseId = 5, Area = "", Description = "", Name = "Single leg balance" },
                        new { ExerciseId = 6, Area = "", Description = "", Name = "Single leg balance – Eyes Closed" },
                        new { ExerciseId = 7, Area = "", Description = "", Name = "Single leg balance – Bosu Ball" },
                        new { ExerciseId = 8, Area = "", Description = "", Name = "Single leg balance – Airex Pad" },
                        new { ExerciseId = 9, Area = "", Description = "", Name = "Tandem balance" },
                        new { ExerciseId = 10, Area = "", Description = "", Name = "Modified tandem balance" },
                        new { ExerciseId = 11, Area = "", Description = "", Name = "Tandem balance on Airex Pad" },
                        new { ExerciseId = 12, Area = "", Description = "Use tactile cueing medial/inferior to ASIS as needed", Name = "Transverse Abdominus Activation" },
                        new { ExerciseId = 13, Area = "", Description = "Use tactile cueing medial/inferior to ASIS as needed", Name = "Transverse Abdominus Activation with Exercise Ball" },
                        new { ExerciseId = 14, Area = "", Description = "Have patient place one hand on umbilicus, and other over sternum with focus on making lower hand move with breath", Name = "Diaphragmatic Breathing" },
                        new { ExerciseId = 15, Area = "", Description = "", Name = "Inner Core Marching" },
                        new { ExerciseId = 16, Area = "", Description = "Use tactile cueing medial/inferior to ASIS as needed", Name = "Transverse Abdominus Activation with single leg slides alt." },
                        new { ExerciseId = 17, Area = "", Description = "Use tactile cueing medial/inferior to ASIS as needed", Name = "Transverse Abdominus Activation with double leg slide" },
                        new { ExerciseId = 18, Area = "", Description = "Stop prior to contralateral hip rising off the table", Name = "Lower trunk rotation" },
                        new { ExerciseId = 19, Area = "", Description = "Pain free range", Name = "Single Knee to Chest" },
                        new { ExerciseId = 20, Area = "", Description = "", Name = "Double Knee to Chest" },
                        new { ExerciseId = 21, Area = "", Description = "", Name = "Lumbar Multifidus Activation – Contralateral SL Modified Bridge" },
                        new { ExerciseId = 22, Area = "", Description = "Manual resistance as needed", Name = "Lumbar Multifidus Activation – Prone Contralateral UE Lift" },
                        new { ExerciseId = 23, Area = "", Description = "", Name = "Glute Bridge" },
                        new { ExerciseId = 24, Area = "", Description = "", Name = "Pec Major Stretch on Foam Roll" },
                        new { ExerciseId = 25, Area = "", Description = "", Name = "Supine SL Knee Extension (Hamstring stretch/neuroglide)" },
                        new { ExerciseId = 26, Area = "", Description = "", Name = "90/90 Arm Swing" },
                        new { ExerciseId = 27, Area = "", Description = "", Name = "90/90 Thoracic Rotation" },
                        new { ExerciseId = 28, Area = "", Description = "Use tactile cueing medial/inferior to ASIS as needed for TA activation", Name = "ASLR" },
                        new { ExerciseId = 29, Area = "", Description = "", Name = "Hamstring Stretch with Rope" },
                        new { ExerciseId = 30, Area = "", Description = "", Name = "Hip Adductor Stretch with Rope" },
                        new { ExerciseId = 31, Area = "", Description = "", Name = "Piriformis stretch with hip flexed at 30 deg" },
                        new { ExerciseId = 32, Area = "", Description = "", Name = "Piriformis stretch with hip flexed at 90 deg" },
                        new { ExerciseId = 33, Area = "", Description = "", Name = "Reverse Plank" },
                        new { ExerciseId = 34, Area = "", Description = "Make sure that hips are stacked and leg is slightly in extension", Name = "Sidelying Straight Leg Hip Abduction" },
                        new { ExerciseId = 35, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Flexion" },
                        new { ExerciseId = 36, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Extension" },
                        new { ExerciseId = 37, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Flexion - Extension" },
                        new { ExerciseId = 38, Area = "", Description = "Make sure that hips are stacked, legs are slightly bent", Name = "Sidelying Clamshell" },
                        new { ExerciseId = 39, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Bicycles (Clockwise)" },
                        new { ExerciseId = 40, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Bicycles (Counterclockwise)" },
                        new { ExerciseId = 41, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Circles (Clockwise)" },
                        new { ExerciseId = 42, Area = "", Description = "Make sure that hips are stacked", Name = "Sidelying Hip Circles (Counterclockwise)" },
                        new { ExerciseId = 43, Area = "", Description = "Make sure that hips are stacked", Name = "Side Plank – on elbow" },
                        new { ExerciseId = 44, Area = "", Description = "Make sure that hips are stacked", Name = "Side Plank – on Hand" },
                        new { ExerciseId = 45, Area = "", Description = "Make sure that hips are stacked", Name = "TRX Side Plank – on elbow" },
                        new { ExerciseId = 46, Area = "", Description = "Make sure that hips are stacked", Name = "TRX Side Plank – on hand" },
                        new { ExerciseId = 47, Area = "", Description = "Make sure that hips are stacked", Name = "Side Plank – on elbow with leg elevated" },
                        new { ExerciseId = 48, Area = "", Description = "Put shoulder blades into back pockets", Name = "Prone Lower Trapezius Activation" },
                        new { ExerciseId = 49, Area = "", Description = "Make sure that hips are stacked", Name = "Plank – on elbows" },
                        new { ExerciseId = 50, Area = "", Description = "Make sure that hips are stacked", Name = "Plank – on hands" },
                        new { ExerciseId = 51, Area = "", Description = "Make sure that hips are stacked", Name = "Modified Plank – on hands" },
                        new { ExerciseId = 52, Area = "", Description = "", Name = "Prone Superman Lift" },
                        new { ExerciseId = 53, Area = "", Description = "", Name = "Prone UE lift and contralateral LE lift" },
                        new { ExerciseId = 54, Area = "", Description = "", Name = "Prone Knee Flexion" },
                        new { ExerciseId = 55, Area = "", Description = "", Name = "Prone Knee Extension Hang" },
                        new { ExerciseId = 56, Area = "", Description = "", Name = "Prone Lumbar Extension – on elbows" },
                        new { ExerciseId = 57, Area = "", Description = "", Name = "Prone Lunbar Extension – on hands" },
                        new { ExerciseId = 58, Area = "", Description = "", Name = "Prone Lumbar Extension Press Ups" },
                        new { ExerciseId = 59, Area = "", Description = "", Name = "Quadruped Thoracic Rotation" },
                        new { ExerciseId = 60, Area = "", Description = "", Name = "Quadruped Bent Knee Hip Abduction" },
                        new { ExerciseId = 61, Area = "", Description = "", Name = "Quadruped Hip Extension – Straight Leg" },
                        new { ExerciseId = 62, Area = "", Description = "", Name = "Quadruped Hip Extension – Bent Leg" },
                        new { ExerciseId = 63, Area = "", Description = "", Name = "Quadruped Bird Dog" },
                        new { ExerciseId = 64, Area = "", Description = "", Name = "Quadruped Cat/Cows" },
                        new { ExerciseId = 65, Area = "", Description = "", Name = "Quadruped Hip Rocking – Hips Externally Rotated" },
                        new { ExerciseId = 66, Area = "", Description = "", Name = "Quadruped Hip Rocking – Hips Internally Rotated" },
                        new { ExerciseId = 67, Area = "", Description = "", Name = "Kneeling Chop with Theraband" },
                        new { ExerciseId = 68, Area = "", Description = "Back leg elevated", Name = "Kneeling Super Quad Stretch" },
                        new { ExerciseId = 69, Area = "", Description = "", Name = "Sit to Stand" },
                        new { ExerciseId = 70, Area = "", Description = "", Name = "Squats" },
                        new { ExerciseId = 71, Area = "", Description = "", Name = "Lunge" },
                        new { ExerciseId = 72, Area = "", Description = "", Name = "KB Swing – 2 arm" },
                        new { ExerciseId = 73, Area = "", Description = "", Name = "KB Swing – 1 arm" },
                        new { ExerciseId = 74, Area = "", Description = "", Name = "KB Windmill" },
                        new { ExerciseId = 75, Area = "", Description = "", Name = "KB Figure 8" },
                        new { ExerciseId = 76, Area = "", Description = "", Name = "KB 1 Arm Deadlift" },
                        new { ExerciseId = 77, Area = "", Description = "", Name = "Suitcase carry" },
                        new { ExerciseId = 78, Area = "", Description = "", Name = "Overhead carry" },
                        new { ExerciseId = 79, Area = "", Description = "", Name = "Glute Sets" },
                        new { ExerciseId = 80, Area = "", Description = "", Name = "Quad sets" },
                        new { ExerciseId = 81, Area = "", Description = "", Name = "Heel slides" },
                        new { ExerciseId = 82, Area = "", Description = "", Name = "Wall Slides UE" },
                        new { ExerciseId = 83, Area = "", Description = "", Name = "Wall Slides LE" },
                        new { ExerciseId = 84, Area = "", Description = "", Name = "Seated Knee Flexion" },
                        new { ExerciseId = 85, Area = "", Description = "", Name = "Supine Hip Abduction" },
                        new { ExerciseId = 86, Area = "", Description = "", Name = "LAQ" },
                        new { ExerciseId = 87, Area = "", Description = "", Name = "SAQ" },
                        new { ExerciseId = 88, Area = "", Description = "", Name = "AROM Dorsiflexion" },
                        new { ExerciseId = 89, Area = "", Description = "", Name = "Theraband Dorsiflexion" },
                        new { ExerciseId = 90, Area = "", Description = "", Name = "AROM Plantarflexion" },
                        new { ExerciseId = 91, Area = "", Description = "", Name = "Theraband Plantarflexion" },
                        new { ExerciseId = 92, Area = "", Description = "", Name = "AROM Eversion - Ankle" },
                        new { ExerciseId = 93, Area = "", Description = "", Name = "Theraband Eversion - Ankle" },
                        new { ExerciseId = 94, Area = "", Description = "", Name = "AROM Inversion - Ankle" },
                        new { ExerciseId = 95, Area = "", Description = "", Name = "Theraband Inversion - Ankle" },
                        new { ExerciseId = 96, Area = "", Description = "", Name = "AROM Shoulder Flexion" },
                        new { ExerciseId = 97, Area = "", Description = "", Name = "Theraband Shoulder Flexion" },
                        new { ExerciseId = 98, Area = "", Description = "Cue for elbows aligned with shoulder and push into wall", Name = "Wall Slides" },
                        new { ExerciseId = 99, Area = "", Description = "", Name = "AROM Shoulder Abduction" },
                        new { ExerciseId = 100, Area = "", Description = "", Name = "AROM Shoulder External Rotation" },
                        new { ExerciseId = 101, Area = "", Description = "Towel roll between UE and trunk", Name = "Theraband Shoulder External Rotation (Neutral)" },
                        new { ExerciseId = 102, Area = "", Description = "", Name = "Theraband Shoulder External Rotation (90/90)" },
                        new { ExerciseId = 103, Area = "", Description = "", Name = "AROM Shoulder Internal Rotation" },
                        new { ExerciseId = 104, Area = "", Description = "Towel roll between UE and trunk", Name = "Theraband Shoulder Internal Rotation (Neutral)" },
                        new { ExerciseId = 105, Area = "", Description = "", Name = "Theraband Shoulder Internal Rotation (90/90)" },
                        new { ExerciseId = 106, Area = "", Description = "", Name = "AROM Cervical Rotation" },
                        new { ExerciseId = 107, Area = "", Description = "", Name = "AROM Cervical Flexion" },
                        new { ExerciseId = 108, Area = "", Description = "", Name = "AROM Cervical Extension" },
                        new { ExerciseId = 109, Area = "", Description = "", Name = "Chin Tucks (Supine)" },
                        new { ExerciseId = 110, Area = "", Description = "", Name = "Chin Tucks (Seated)" },
                        new { ExerciseId = 111, Area = "", Description = "", Name = "Chin Tucks (Quadruped)" },
                        new { ExerciseId = 112, Area = "", Description = "", Name = "Triceps Extension" },
                        new { ExerciseId = 113, Area = "", Description = "", Name = "Theraband Shoulder Extension" },
                        new { ExerciseId = 114, Area = "", Description = "", Name = "Biceps Curl" },
                        new { ExerciseId = 115, Area = "", Description = "", Name = "Hammer Curl" },
                        new { ExerciseId = 116, Area = "", Description = "", Name = "UE Hang" },
                        new { ExerciseId = 117, Area = "", Description = "", Name = "TRX Chest Press" },
                        new { ExerciseId = 118, Area = "", Description = "", Name = "Back Row" },
                        new { ExerciseId = 119, Area = "", Description = "", Name = "Single Arm Back Row" },
                        new { ExerciseId = 120, Area = "", Description = "", Name = "TRX Back Row" },
                        new { ExerciseId = 121, Area = "", Description = "", Name = "Latissimus Dorsi Pulldown" },
                        new { ExerciseId = 122, Area = "", Description = "Don’t allow hip to ER, back foot returns slow, limit trunk sway", Name = "Theraband Standing Hip Abduction – Around Feet" },
                        new { ExerciseId = 123, Area = "", Description = "Don’t allow hip to ER, back foot returns slow, limit trunk sway", Name = "Theraband Standing Hip Abduction – Around Ankles" },
                        new { ExerciseId = 124, Area = "", Description = "Don’t allow hip to ER, back foot returns slow, limit trunk sway", Name = "Theraband Standing Hip Abduction – Around Ankles" },
                        new { ExerciseId = 125, Area = "", Description = "Watch for knee valgus", Name = "Step up" },
                        new { ExerciseId = 126, Area = "", Description = "Watch for knee valgus", Name = "Step down" },
                        new { ExerciseId = 127, Area = "", Description = "Watch for knee valgus", Name = "Power ups" },
                        new { ExerciseId = 128, Area = "", Description = "", Name = "Hurdle step over" },
                        new { ExerciseId = 129, Area = "", Description = "", Name = "Lateral Hurdle step over" },
                        new { ExerciseId = 130, Area = "", Description = "", Name = "Knee Extension Stretch" },
                        new { ExerciseId = 131, Area = "", Description = "", Name = "Doorway Pec Stretch" },
                        new { ExerciseId = 132, Area = "", Description = "Towel roll between UE and trunk", Name = "Sidelying Shoulder ER" },
                        new { ExerciseId = 133, Area = "", Description = "", Name = "Sidelying Lat Stretch" },
                        new { ExerciseId = 134, Area = "", Description = "", Name = "Standing Quad Stretch" },
                        new { ExerciseId = 135, Area = "", Description = "", Name = "Standing Hamstring Stretch" },
                        new { ExerciseId = 136, Area = "", Description = "", Name = "Standing Hamstring Stretch Legs Crossed" },
                        new { ExerciseId = 137, Area = "", Description = "", Name = "Standing Calf Stretch with Foot Propped" },
                        new { ExerciseId = 138, Area = "", Description = "", Name = "Standing Calf Stretch in Lunge Position" },
                        new { ExerciseId = 139, Area = "", Description = "", Name = "Dynamic Warm Up Knee Pull" },
                        new { ExerciseId = 140, Area = "", Description = "", Name = "Dynamic Warm Up Gate Opener" },
                        new { ExerciseId = 141, Area = "", Description = "", Name = "Dynamic Warm Up Gate Closer" },
                        new { ExerciseId = 142, Area = "", Description = "", Name = "Dynamic Warm Up Butt Kickers" },
                        new { ExerciseId = 143, Area = "", Description = "", Name = "Dynamic Warm Up Quad Pull" },
                        new { ExerciseId = 144, Area = "", Description = "", Name = "Dynamic Warm Up Side Lunge Alternating" },
                        new { ExerciseId = 145, Area = "", Description = "", Name = "Dynamic Warm Up Lunge with In-step" },
                        new { ExerciseId = 146, Area = "", Description = "", Name = "Dynamic Warm Up Inch Worm" },
                        new { ExerciseId = 147, Area = "", Description = "", Name = "Dynamic Warm Frankenstein Walk" },
                        new { ExerciseId = 148, Area = "", Description = "", Name = "Dynamic Warm Monster Walk" },
                        new { ExerciseId = 149, Area = "", Description = "", Name = "RDL Dumbbell" },
                        new { ExerciseId = 150, Area = "", Description = "", Name = "RDL Barbell" },
                        new { ExerciseId = 151, Area = "", Description = "", Name = "Exercise Ball Pelvic Tilts" },
                        new { ExerciseId = 152, Area = "", Description = "", Name = "Exercise Ball Marching" },
                        new { ExerciseId = 153, Area = "", Description = "", Name = "Exercise Ball Ts" },
                        new { ExerciseId = 154, Area = "", Description = "", Name = "Exercise Ball Ys" },
                        new { ExerciseId = 155, Area = "", Description = "", Name = "Exercise Ball Is" },
                        new { ExerciseId = 156, Area = "", Description = "", Name = "TRX Ts" },
                        new { ExerciseId = 157, Area = "", Description = "", Name = "TRX Ys" },
                        new { ExerciseId = 158, Area = "", Description = "", Name = "TRX Is" },
                        new { ExerciseId = 159, Area = "", Description = "", Name = "TRX Single Arm Row" },
                        new { ExerciseId = 160, Area = "", Description = "", Name = "TRX Biceps Curl" },
                        new { ExerciseId = 161, Area = "", Description = "", Name = "TRX Triceps Press" },
                        new { ExerciseId = 162, Area = "", Description = "", Name = "TRX Chest Fly" },
                        new { ExerciseId = 163, Area = "", Description = "", Name = "TRX Plank" },
                        new { ExerciseId = 164, Area = "", Description = "", Name = "TRX Body Saw" },
                        new { ExerciseId = 165, Area = "", Description = "", Name = "TRX Pike" },
                        new { ExerciseId = 166, Area = "", Description = "", Name = "Cable Pallof Press" },
                        new { ExerciseId = 167, Area = "", Description = "", Name = "Cable Shoulder ER" },
                        new { ExerciseId = 168, Area = "", Description = "", Name = "Cable Shoulder ER 90/90" },
                        new { ExerciseId = 169, Area = "", Description = "", Name = "Cable Biceps Curl" },
                        new { ExerciseId = 170, Area = "", Description = "", Name = "Cable Triceps Press" },
                        new { ExerciseId = 171, Area = "", Description = "", Name = "Upper Trapezius Stretch" },
                        new { ExerciseId = 172, Area = "", Description = "", Name = "Levator Scapulae Stretch" },
                        new { ExerciseId = 173, Area = "", Description = "", Name = "Shoulder Wand Flexion" },
                        new { ExerciseId = 174, Area = "", Description = "", Name = "Shoulder Wand Flexion (Supine)" },
                        new { ExerciseId = 175, Area = "", Description = "", Name = "Shoulder Wand Abduction" },
                        new { ExerciseId = 176, Area = "", Description = "", Name = "Shoulder Wand ER" },
                        new { ExerciseId = 177, Area = "", Description = "", Name = "Shoulder Wand IR" },
                        new { ExerciseId = 178, Area = "", Description = "", Name = "Shoulder Flexion Ladder" },
                        new { ExerciseId = 179, Area = "", Description = "", Name = "Shoulder Flexion Table Slide" },
                        new { ExerciseId = 180, Area = "", Description = "", Name = "Shoulder Pendulums" },
                        new { ExerciseId = 181, Area = "", Description = "", Name = "Scapular Squeezes" },
                        new { ExerciseId = 182, Area = "", Description = "", Name = "Wrist Flexion  - Theraband" },
                        new { ExerciseId = 183, Area = "", Description = "", Name = "Wrist Flexion  - AROM" },
                        new { ExerciseId = 184, Area = "", Description = "", Name = "Wrist Extension  - Theraband" },
                        new { ExerciseId = 185, Area = "", Description = "", Name = "Wrist Extension  - AROM" },
                        new { ExerciseId = 186, Area = "", Description = "", Name = "Wrist Ulnar Deviation  - Theraband" },
                        new { ExerciseId = 187, Area = "", Description = "", Name = "Wrist Ulnar Deviation  - AROM" },
                        new { ExerciseId = 188, Area = "", Description = "", Name = "Wrist Radial Deviation   - Theraband" },
                        new { ExerciseId = 189, Area = "", Description = "", Name = "Wrist Radial Deviation   - AROM" },
                        new { ExerciseId = 190, Area = "", Description = "", Name = "Wrist Supination  - Theraband" },
                        new { ExerciseId = 191, Area = "", Description = "", Name = "Wrist Supination  - AROM" },
                        new { ExerciseId = 192, Area = "", Description = "", Name = "Wrist Pronation  - Theraband" },
                        new { ExerciseId = 193, Area = "", Description = "", Name = "Wrist Pronation  - AROM" }
                    );
                });

            modelBuilder.Entity("PhysicalTherapy.Models.MessageLog", b =>
                {
                    b.Property<int>("MessageLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate");

                    b.Property<string>("Message");

                    b.Property<int?>("PatientId");

                    b.Property<int?>("RoutineId");

                    b.Property<int?>("TherapistId");

                    b.HasKey("MessageLogId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RoutineId");

                    b.HasIndex("TherapistId");

                    b.ToTable("MessageLogs");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType");

                    b.Property<string>("Bio");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("TherapistId");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("PatientId");

                    b.HasIndex("TherapistId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Patients");

                    b.HasData(
                        new { PatientId = 1, AccountType = 2, Bio = "bad back", DateOfBirth = new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), Email = "one@email.com", FirstName = "Hung", LastName = "thats-me", PhoneNumber = "911", TherapistId = 1, Username = "Alex" },
                        new { PatientId = 2, AccountType = 2, Bio = "bad knees", DateOfBirth = new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), Email = "two@email.com", FirstName = "Also Hung", LastName = "2nd", PhoneNumber = "1800", TherapistId = 1, Username = "Hung" },
                        new { PatientId = 3, AccountType = 2, Bio = "accident prone", DateOfBirth = new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), Email = "three@email.com", FirstName = "Sike", LastName = "Still-Hung", PhoneNumber = "411", TherapistId = 1, Username = "Tyger" }
                    );
                });

            modelBuilder.Entity("PhysicalTherapy.Models.PostRoutineSurvey", b =>
                {
                    b.Property<int>("PostRoutineSurveyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed");

                    b.Property<int>("LevelOfDifficulty");

                    b.Property<int>("LevelOfPain");

                    b.Property<int>("LevelOfTiredness");

                    b.Property<string>("Note");

                    b.HasKey("PostRoutineSurveyId");

                    b.ToTable("PostRoutineSurveys");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Routine", b =>
                {
                    b.Property<int>("RoutineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsComplete");

                    b.Property<bool>("IsNew");

                    b.Property<int>("PatientId");

                    b.Property<int?>("PostRoutineSurveyId");

                    b.HasKey("RoutineId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PostRoutineSurveyId")
                        .IsUnique()
                        .HasFilter("[PostRoutineSurveyId] IS NOT NULL");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.RoutineExercise", b =>
                {
                    b.Property<int>("RoutineExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseId");

                    b.Property<int?>("FrequencyPerDay");

                    b.Property<decimal?>("HoldLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notes");

                    b.Property<int?>("Rep");

                    b.Property<int>("RoutineId");

                    b.Property<int?>("Sets");

                    b.HasKey("RoutineExerciseId");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineExercises");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Therapist", b =>
                {
                    b.Property<int>("TherapistId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType");

                    b.Property<string>("Bio");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("TherapistId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Therapists");

                    b.HasData(
                        new { TherapistId = 1, AccountType = 0, Bio = "New Dr.", DateOfBirth = new DateTime(2019, 1, 16, 0, 0, 0, 0, DateTimeKind.Local), Email = "Test@email.com", FirstName = "DR.", LastName = "Doctor", PhoneNumber = "911", Username = "TygerHugh" }
                    );
                });

            modelBuilder.Entity("PhysicalTherapy.Models.MessageLog", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("PhysicalTherapy.Models.Routine", "Routine")
                        .WithMany("ListOfMessageLogs")
                        .HasForeignKey("RoutineId");

                    b.HasOne("PhysicalTherapy.Models.Therapist", "Therapist")
                        .WithMany()
                        .HasForeignKey("TherapistId");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Patient", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Therapist", "Therapist")
                        .WithMany("ListOfPatients")
                        .HasForeignKey("TherapistId");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Routine", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhysicalTherapy.Models.PostRoutineSurvey", "PostRoutineSurvey")
                        .WithOne()
                        .HasForeignKey("PhysicalTherapy.Models.Routine", "PostRoutineSurveyId");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.RoutineExercise", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhysicalTherapy.Models.Routine", "Routine")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
