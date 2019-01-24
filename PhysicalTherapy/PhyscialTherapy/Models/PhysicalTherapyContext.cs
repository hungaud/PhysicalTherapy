using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
using PhysicalTherapy.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class PhysicalTherapyContext : DbContext
    {
        public PhysicalTherapyContext(DbContextOptions<PhysicalTherapyContext> options)
            : base(options)
        {

        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Exercise> Excercises { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PostRoutineSurvey> PostRoutineSurveys { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<Therapist> Therapists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
            });

            modelBuilder.Entity<Credential>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
            });

            modelBuilder.Entity<MessageLog>(entity =>
            {
                entity.HasOne(p => p.Patient);
                entity.HasOne(r => r.Routine)
                    .WithMany(ml => ml.ListOfMessageLogs)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(t => t.Therapist);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
            });

            modelBuilder.Entity<Routine>(entity =>
            {
                entity.HasOne(p => p.Patient);
                entity.HasOne(prs => prs.PostRoutineSurvey)
                    .WithOne()
                    .HasForeignKey<Routine>(fk => fk.PostRoutineSurveyId);
                entity.HasMany(re => re.RoutineExercises)
                    .WithOne(r => r.Routine);
                entity.HasMany(ml => ml.ListOfMessageLogs);
            });

            modelBuilder.Entity<RoutineExercise>(entity =>
            {
                entity.HasOne(e => e.Exercise);
                entity.HasOne(r => r.Routine)
                    .WithMany(re => re.RoutineExercises)
                    .HasForeignKey(fk => fk.RoutineId);
            });

            modelBuilder.Entity<Therapist>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
            });

            SeedExercise(modelBuilder);
            SeedTherapistAndTestData(modelBuilder);
            SeedRoutinesTestData(modelBuilder);
        }

        #region "Seed Test Data"

        private void SeedTherapistAndTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Therapist>(e =>
            {
                e.HasData
                (
                    new { AccountType = AccountType.THERAPIST, Bio= "New Dr.", DateOfBirth = DateTime.Today, Email = "Test@email.com", FirstName = "DR.", LastName = "Doctor", PhoneNumber = "911", TherapistId = 1, Username = "TygerHugh" }
                );
            });

            modelBuilder.Entity<Patient>(e =>
            {
                e.HasData
                (
                    new { AccountType = AccountType.PATIENT, Bio = "bad back", DateOfBirth = DateTime.Today, Email = "one@email.com", FirstName = "Hung", LastName = "thats-me", PatientId = 1, PhoneNumber = "911", TherapistId = 1, Username = "Alex" },
                    new { AccountType = AccountType.PATIENT, Bio = "bad knees", DateOfBirth = DateTime.Today, Email = "two@email.com", FirstName = "Also Hung", LastName = "2nd", PatientId = 2, PhoneNumber = "1800", TherapistId = 1, Username = "Hung" },
                    new { AccountType = AccountType.PATIENT, Bio = "accident prone", DateOfBirth = DateTime.Today, Email = "three@email.com", FirstName = "Sike", LastName = "Still-Hung", PatientId = 3, PhoneNumber = "411", TherapistId = 1, Username = "Tyger" }
                );
            });

        }

        private void SeedRoutinesTestData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Routine>(e =>
            {
                e.HasData(
                    new { Description = "Routine number 1 not Active", IsComplete = true, IsNew = false, PatientId = 1, RoutineId = 1 },
                    new { Description = "Routine number 2 Active", IsComplete = false, IsNew = true, PatientId = 1, RoutineId = 2 },
                    new { Description = "Routine number 3 Active", IsComplete = false, IsNew = true, PatientId = 2, RoutineId = 3 }
                );
            });

            modelBuilder.Entity<RoutineExercise>(e =>
            {
                e.HasData(
                    new { ExerciseId = 1, HoldLength = (decimal?) 30, FrequencyPerDay = 1, Notes = "holding for 30 seconds", RoutineExerciseId = 1, RoutineId = 1, Sets = 3 },
                    new { ExerciseId = 5, HoldLength = (decimal?) 45, FrequencyPerDay = 1, Notes = "holding for 45 seconds", RoutineExerciseId = 2, RoutineId = 1, Sets = 3 },
                    new { ExerciseId = 15, FrequencyPerDay = 1, Notes = "holding for 30 seconds", Reps = 10, RoutineExerciseId = 3, RoutineId = 1, Sets = 3 },
                    
                    new { ExerciseId = 1, HoldLength = (decimal?) 30, FrequencyPerDay = 1, Notes = "2nd routine holding for 30 seconds", RoutineExerciseId = 4, RoutineId = 2, Sets = 3 },
                    new { ExerciseId = 5, HoldLength = (decimal?) 45, FrequencyPerDay = 1, Notes = "2nd routine holding for 45 seconds", RoutineExerciseId = 5, RoutineId = 2, Sets = 3 },
                    new { ExerciseId = 15, FrequencyPerDay = 1, Notes = "2nd routine holding for 30 seconds", Reps = 10, RoutineExerciseId = 6, RoutineId = 2, Sets = 3 },
                   
                    new { ExerciseId = 1, HoldLength = (decimal?) 30, FrequencyPerDay = 1, Notes = "3rd routine holding for 30 seconds", RoutineExerciseId = 7, RoutineId = 3, Sets = 3 },
                    new { ExerciseId = 5, HoldLength = (decimal?) 45, FrequencyPerDay = 1, Notes = "3rd routine holding for 45 seconds", RoutineExerciseId = 8, RoutineId = 3, Sets = 3 },
                    new { ExerciseId = 15, FrequencyPerDay = 1, Notes = "3rd routine holding for 30 seconds", Reps = 10, RoutineExerciseId = 9, RoutineId = 3, Sets = 3 }

                );
            });
        }

        #endregion

        #region "Seed Data"
        private void SeedExercise(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(e =>
            {
                e.HasData
                (
                    new { ExerciseId = 1, Name = "2-legged balance (Narrow Base of Support)", Description = "", Area = "" },
                    new { ExerciseId = 2, Name = "2-legged balance (Narrow Base of Support) – Eyes Closed", Description = "", Area = "" },
                    new { ExerciseId = 3, Name = "2-legged balance (Narrow Base of Support) – Bosu Ball", Description = "", Area = "" },
                    new { ExerciseId = 4, Name = "2-legged balance (Narrow Base of Support) – Airex Pad", Description = "", Area = "" },
                    new { ExerciseId = 5, Name = "Single leg balance", Description = "", Area = "" },
                    new { ExerciseId = 6, Name = "Single leg balance – Eyes Closed", Description = "", Area = "" },
                    new { ExerciseId = 7, Name = "Single leg balance – Bosu Ball", Description = "", Area = "" },
                    new { ExerciseId = 8, Name = "Single leg balance – Airex Pad", Description = "", Area = "" },
                    new { ExerciseId = 9, Name = "Tandem balance", Description = "", Area = "" },
                    new { ExerciseId = 10, Name = "Modified tandem balance", Description = "", Area = "" },
                    new { ExerciseId = 11, Name = "Tandem balance on Airex Pad", Description = "", Area = "" },
                    new { ExerciseId = 12, Name = "Transverse Abdominus Activation", Description = "Use tactile cueing medial/inferior to ASIS as needed", Area = "" },
                    new { ExerciseId = 13, Name = "Transverse Abdominus Activation with Exercise Ball", Description = "Use tactile cueing medial/inferior to ASIS as needed", Area = "" },
                    new { ExerciseId = 14, Name = "Diaphragmatic Breathing", Description = "Have patient place one hand on umbilicus, and other over sternum with focus on making lower hand move with breath", Area = "" },
                    new { ExerciseId = 15, Name = "Inner Core Marching", Description = "", Area = "" },
                    new { ExerciseId = 16, Name = "Transverse Abdominus Activation with single leg slides alt.", Description = "Use tactile cueing medial/inferior to ASIS as needed", Area = "" },
                    new { ExerciseId = 17, Name = "Transverse Abdominus Activation with double leg slide", Description = "Use tactile cueing medial/inferior to ASIS as needed", Area = "" },
                    new { ExerciseId = 18, Name = "Lower trunk rotation", Description = "Stop prior to contralateral hip rising off the table", Area = "" },
                    new { ExerciseId = 19, Name = "Single Knee to Chest", Description = "Pain free range", Area = "" },
                    new { ExerciseId = 20, Name = "Double Knee to Chest", Description = "", Area = "" },
                    new { ExerciseId = 21, Name = "Lumbar Multifidus Activation – Contralateral SL Modified Bridge", Description = "", Area = "" },
                    new { ExerciseId = 22, Name = "Lumbar Multifidus Activation – Prone Contralateral UE Lift", Description = "Manual resistance as needed", Area = "" },
                    new { ExerciseId = 23, Name = "Glute Bridge", Description = "", Area = "" },
                    new { ExerciseId = 24, Name = "Pec Major Stretch on Foam Roll", Description = "", Area = "" },
                    new { ExerciseId = 25, Name = "Supine SL Knee Extension (Hamstring stretch/neuroglide)", Description = "", Area = "" },
                    new { ExerciseId = 26, Name = "90/90 Arm Swing", Description = "", Area = "" },
                    new { ExerciseId = 27, Name = "90/90 Thoracic Rotation", Description = "", Area = "" },
                    new { ExerciseId = 28, Name = "ASLR", Description = "Use tactile cueing medial/inferior to ASIS as needed for TA activation", Area = "" },
                    new { ExerciseId = 29, Name = "Hamstring Stretch with Rope", Description = "", Area = "" },
                    new { ExerciseId = 30, Name = "Hip Adductor Stretch with Rope", Description = "", Area = "" },
                    new { ExerciseId = 31, Name = "Piriformis stretch with hip flexed at 30 deg", Description = "", Area = "" },
                    new { ExerciseId = 32, Name = "Piriformis stretch with hip flexed at 90 deg", Description = "", Area = "" },
                    new { ExerciseId = 33, Name = "Reverse Plank", Description = "", Area = "" },
                    new { ExerciseId = 34, Name = "Sidelying Straight Leg Hip Abduction", Description = "Make sure that hips are stacked and leg is slightly in extension", Area = "" },
                    new { ExerciseId = 35, Name = "Sidelying Hip Flexion", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 36, Name = "Sidelying Hip Extension", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 37, Name = "Sidelying Hip Flexion - Extension", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 38, Name = "Sidelying Clamshell", Description = "Make sure that hips are stacked, legs are slightly bent", Area = "" },
                    new { ExerciseId = 39, Name = "Sidelying Hip Bicycles (Clockwise)", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 40, Name = "Sidelying Hip Bicycles (Counterclockwise)", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 41, Name = "Sidelying Hip Circles (Clockwise)", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 42, Name = "Sidelying Hip Circles (Counterclockwise)", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 43, Name = "Side Plank – on elbow", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 44, Name = "Side Plank – on Hand", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 45, Name = "TRX Side Plank – on elbow", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 46, Name = "TRX Side Plank – on hand", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 47, Name = "Side Plank – on elbow with leg elevated", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 48, Name = "Prone Lower Trapezius Activation", Description = "Put shoulder blades into back pockets", Area = "" },
                    new { ExerciseId = 49, Name = "Plank – on elbows", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 50, Name = "Plank – on hands", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 51, Name = "Modified Plank – on hands", Description = "Make sure that hips are stacked", Area = "" },
                    new { ExerciseId = 52, Name = "Prone Superman Lift", Description = "", Area = "" },
                    new { ExerciseId = 53, Name = "Prone UE lift and contralateral LE lift", Description = "", Area = "" },
                    new { ExerciseId = 54, Name = "Prone Knee Flexion", Description = "", Area = "" },
                    new { ExerciseId = 55, Name = "Prone Knee Extension Hang", Description = "", Area = "" },
                    new { ExerciseId = 56, Name = "Prone Lumbar Extension – on elbows", Description = "", Area = "" },
                    new { ExerciseId = 57, Name = "Prone Lunbar Extension – on hands", Description = "", Area = "" },
                    new { ExerciseId = 58, Name = "Prone Lumbar Extension Press Ups", Description = "", Area = "" },
                    new { ExerciseId = 59, Name = "Quadruped Thoracic Rotation", Description = "", Area = "" },
                    new { ExerciseId = 60, Name = "Quadruped Bent Knee Hip Abduction", Description = "", Area = "" },
                    new { ExerciseId = 61, Name = "Quadruped Hip Extension – Straight Leg", Description = "", Area = "" },
                    new { ExerciseId = 62, Name = "Quadruped Hip Extension – Bent Leg", Description = "", Area = "" },
                    new { ExerciseId = 63, Name = "Quadruped Bird Dog", Description = "", Area = "" },
                    new { ExerciseId = 64, Name = "Quadruped Cat/Cows", Description = "", Area = "" },
                    new { ExerciseId = 65, Name = "Quadruped Hip Rocking – Hips Externally Rotated", Description = "", Area = "" },
                    new { ExerciseId = 66, Name = "Quadruped Hip Rocking – Hips Internally Rotated", Description = "", Area = "" },
                    new { ExerciseId = 67, Name = "Kneeling Chop with Theraband", Description = "", Area = "" },
                    new { ExerciseId = 68, Name = "Kneeling Super Quad Stretch", Description = "Back leg elevated", Area = "" },
                    new { ExerciseId = 69, Name = "Sit to Stand", Description = "", Area = "" },
                    new { ExerciseId = 70, Name = "Squats", Description = "", Area = "" },
                    new { ExerciseId = 71, Name = "Lunge", Description = "", Area = "" },
                    new { ExerciseId = 72, Name = "KB Swing – 2 arm", Description = "", Area = "" },
                    new { ExerciseId = 73, Name = "KB Swing – 1 arm", Description = "", Area = "" },
                    new { ExerciseId = 74, Name = "KB Windmill", Description = "", Area = "" },
                    new { ExerciseId = 75, Name = "KB Figure 8", Description = "", Area = "" },
                    new { ExerciseId = 76, Name = "KB 1 Arm Deadlift", Description = "", Area = "" },
                    new { ExerciseId = 77, Name = "Suitcase carry", Description = "", Area = "" },
                    new { ExerciseId = 78, Name = "Overhead carry", Description = "", Area = "" },
                    new { ExerciseId = 79, Name = "Glute Sets", Description = "", Area = "" },
                    new { ExerciseId = 80, Name = "Quad sets", Description = "", Area = "" },
                    new { ExerciseId = 81, Name = "Heel slides", Description = "", Area = "" },
                    new { ExerciseId = 82, Name = "Wall Slides UE", Description = "", Area = "" },
                    new { ExerciseId = 83, Name = "Wall Slides LE", Description = "", Area = "" },
                    new { ExerciseId = 84, Name = "Seated Knee Flexion", Description = "", Area = "" },
                    new { ExerciseId = 85, Name = "Supine Hip Abduction", Description = "", Area = "" },
                    new { ExerciseId = 86, Name = "LAQ", Description = "", Area = "" },
                    new { ExerciseId = 87, Name = "SAQ", Description = "", Area = "" },
                    new { ExerciseId = 88, Name = "AROM Dorsiflexion", Description = "", Area = "" },
                    new { ExerciseId = 89, Name = "Theraband Dorsiflexion", Description = "", Area = "" },
                    new { ExerciseId = 90, Name = "AROM Plantarflexion", Description = "", Area = "" },
                    new { ExerciseId = 91, Name = "Theraband Plantarflexion", Description = "", Area = "" },
                    new { ExerciseId = 92, Name = "AROM Eversion - Ankle", Description = "", Area = "" },
                    new { ExerciseId = 93, Name = "Theraband Eversion - Ankle", Description = "", Area = "" },
                    new { ExerciseId = 94, Name = "AROM Inversion - Ankle", Description = "", Area = "" },
                    new { ExerciseId = 95, Name = "Theraband Inversion - Ankle", Description = "", Area = "" },
                    new { ExerciseId = 96, Name = "AROM Shoulder Flexion", Description = "", Area = "" },
                    new { ExerciseId = 97, Name = "Theraband Shoulder Flexion", Description = "", Area = "" },
                    new { ExerciseId = 98, Name = "Wall Slides", Description = "Cue for elbows aligned with shoulder and push into wall", Area = "" },
                    new { ExerciseId = 99, Name = "AROM Shoulder Abduction", Description = "", Area = "" },
                    new { ExerciseId = 100, Name = "AROM Shoulder External Rotation", Description = "", Area = "" },
                    new { ExerciseId = 101, Name = "Theraband Shoulder External Rotation (Neutral)", Description = "Towel roll between UE and trunk", Area = "" },
                    new { ExerciseId = 102, Name = "Theraband Shoulder External Rotation (90/90)", Description = "", Area = "" },
                    new { ExerciseId = 103, Name = "AROM Shoulder Internal Rotation", Description = "", Area = "" },
                    new { ExerciseId = 104, Name = "Theraband Shoulder Internal Rotation (Neutral)", Description = "Towel roll between UE and trunk", Area = "" },
                    new { ExerciseId = 105, Name = "Theraband Shoulder Internal Rotation (90/90)", Description = "", Area = "" },
                    new { ExerciseId = 106, Name = "AROM Cervical Rotation", Description = "", Area = "" },
                    new { ExerciseId = 107, Name = "AROM Cervical Flexion", Description = "", Area = "" },
                    new { ExerciseId = 108, Name = "AROM Cervical Extension", Description = "", Area = "" },
                    new { ExerciseId = 109, Name = "Chin Tucks (Supine)", Description = "", Area = "" },
                    new { ExerciseId = 110, Name = "Chin Tucks (Seated)", Description = "", Area = "" },
                    new { ExerciseId = 111, Name = "Chin Tucks (Quadruped)", Description = "", Area = "" },
                    new { ExerciseId = 112, Name = "Triceps Extension", Description = "", Area = "" },
                    new { ExerciseId = 113, Name = "Theraband Shoulder Extension", Description = "", Area = "" },
                    new { ExerciseId = 114, Name = "Biceps Curl", Description = "", Area = "" },
                    new { ExerciseId = 115, Name = "Hammer Curl", Description = "", Area = "" },
                    new { ExerciseId = 116, Name = "UE Hang", Description = "", Area = "" },
                    new { ExerciseId = 117, Name = "TRX Chest Press", Description = "", Area = "" },
                    new { ExerciseId = 118, Name = "Back Row", Description = "", Area = "" },
                    new { ExerciseId = 119, Name = "Single Arm Back Row", Description = "", Area = "" },
                    new { ExerciseId = 120, Name = "TRX Back Row", Description = "", Area = "" },
                    new { ExerciseId = 121, Name = "Latissimus Dorsi Pulldown", Description = "", Area = "" },
                    new { ExerciseId = 122, Name = "Theraband Standing Hip Abduction – Around Feet", Description = "Don’t allow hip to ER, back foot returns slow, limit trunk sway", Area = "" },
                    new { ExerciseId = 123, Name = "Theraband Standing Hip Abduction – Around Ankles", Description = "Don’t allow hip to ER, back foot returns slow, limit trunk sway", Area = "" },
                    new { ExerciseId = 124, Name = "Theraband Standing Hip Abduction – Around Ankles", Description = "Don’t allow hip to ER, back foot returns slow, limit trunk sway", Area = "" },
                    new { ExerciseId = 125, Name = "Step up", Description = "Watch for knee valgus", Area = "" },
                    new { ExerciseId = 126, Name = "Step down", Description = "Watch for knee valgus", Area = "" },
                    new { ExerciseId = 127, Name = "Power ups", Description = "Watch for knee valgus", Area = "" },
                    new { ExerciseId = 128, Name = "Hurdle step over", Description = "", Area = "" },
                    new { ExerciseId = 129, Name = "Lateral Hurdle step over", Description = "", Area = "" },
                    new { ExerciseId = 130, Name = "Knee Extension Stretch", Description = "", Area = "" },
                    new { ExerciseId = 131, Name = "Doorway Pec Stretch", Description = "", Area = "" },
                    new { ExerciseId = 132, Name = "Sidelying Shoulder ER", Description = "Towel roll between UE and trunk", Area = "" },
                    new { ExerciseId = 133, Name = "Sidelying Lat Stretch", Description = "", Area = "" },
                    new { ExerciseId = 134, Name = "Standing Quad Stretch", Description = "", Area = "" },
                    new { ExerciseId = 135, Name = "Standing Hamstring Stretch", Description = "", Area = "" },
                    new { ExerciseId = 136, Name = "Standing Hamstring Stretch Legs Crossed", Description = "", Area = "" },
                    new { ExerciseId = 137, Name = "Standing Calf Stretch with Foot Propped", Description = "", Area = "" },
                    new { ExerciseId = 138, Name = "Standing Calf Stretch in Lunge Position", Description = "", Area = "" },
                    new { ExerciseId = 139, Name = "Dynamic Warm Up Knee Pull", Description = "", Area = "" },
                    new { ExerciseId = 140, Name = "Dynamic Warm Up Gate Opener", Description = "", Area = "" },
                    new { ExerciseId = 141, Name = "Dynamic Warm Up Gate Closer", Description = "", Area = "" },
                    new { ExerciseId = 142, Name = "Dynamic Warm Up Butt Kickers", Description = "", Area = "" },
                    new { ExerciseId = 143, Name = "Dynamic Warm Up Quad Pull", Description = "", Area = "" },
                    new { ExerciseId = 144, Name = "Dynamic Warm Up Side Lunge Alternating", Description = "", Area = "" },
                    new { ExerciseId = 145, Name = "Dynamic Warm Up Lunge with In-step", Description = "", Area = "" },
                    new { ExerciseId = 146, Name = "Dynamic Warm Up Inch Worm", Description = "", Area = "" },
                    new { ExerciseId = 147, Name = "Dynamic Warm Frankenstein Walk", Description = "", Area = "" },
                    new { ExerciseId = 148, Name = "Dynamic Warm Monster Walk", Description = "", Area = "" },
                    new { ExerciseId = 149, Name = "RDL Dumbbell", Description = "", Area = "" },
                    new { ExerciseId = 150, Name = "RDL Barbell", Description = "", Area = "" },
                    new { ExerciseId = 151, Name = "Exercise Ball Pelvic Tilts", Description = "", Area = "" },
                    new { ExerciseId = 152, Name = "Exercise Ball Marching", Description = "", Area = "" },
                    new { ExerciseId = 153, Name = "Exercise Ball Ts", Description = "", Area = "" },
                    new { ExerciseId = 154, Name = "Exercise Ball Ys", Description = "", Area = "" },
                    new { ExerciseId = 155, Name = "Exercise Ball Is", Description = "", Area = "" },
                    new { ExerciseId = 156, Name = "TRX Ts", Description = "", Area = "" },
                    new { ExerciseId = 157, Name = "TRX Ys", Description = "", Area = "" },
                    new { ExerciseId = 158, Name = "TRX Is", Description = "", Area = "" },
                    new { ExerciseId = 159, Name = "TRX Single Arm Row", Description = "", Area = "" },
                    new { ExerciseId = 160, Name = "TRX Biceps Curl", Description = "", Area = "" },
                    new { ExerciseId = 161, Name = "TRX Triceps Press", Description = "", Area = "" },
                    new { ExerciseId = 162, Name = "TRX Chest Fly", Description = "", Area = "" },
                    new { ExerciseId = 163, Name = "TRX Plank", Description = "", Area = "" },
                    new { ExerciseId = 164, Name = "TRX Body Saw", Description = "", Area = "" },
                    new { ExerciseId = 165, Name = "TRX Pike", Description = "", Area = "" },
                    new { ExerciseId = 166, Name = "Cable Pallof Press", Description = "", Area = "" },
                    new { ExerciseId = 167, Name = "Cable Shoulder ER", Description = "", Area = "" },
                    new { ExerciseId = 168, Name = "Cable Shoulder ER 90/90", Description = "", Area = "" },
                    new { ExerciseId = 169, Name = "Cable Biceps Curl", Description = "", Area = "" },
                    new { ExerciseId = 170, Name = "Cable Triceps Press", Description = "", Area = "" },
                    new { ExerciseId = 171, Name = "Upper Trapezius Stretch", Description = "", Area = "" },
                    new { ExerciseId = 172, Name = "Levator Scapulae Stretch", Description = "", Area = "" },
                    new { ExerciseId = 173, Name = "Shoulder Wand Flexion", Description = "", Area = "" },
                    new { ExerciseId = 174, Name = "Shoulder Wand Flexion (Supine)", Description = "", Area = "" },
                    new { ExerciseId = 175, Name = "Shoulder Wand Abduction", Description = "", Area = "" },
                    new { ExerciseId = 176, Name = "Shoulder Wand ER", Description = "", Area = "" },
                    new { ExerciseId = 177, Name = "Shoulder Wand IR", Description = "", Area = "" },
                    new { ExerciseId = 178, Name = "Shoulder Flexion Ladder", Description = "", Area = "" },
                    new { ExerciseId = 179, Name = "Shoulder Flexion Table Slide", Description = "", Area = "" },
                    new { ExerciseId = 180, Name = "Shoulder Pendulums", Description = "", Area = "" },
                    new { ExerciseId = 181, Name = "Scapular Squeezes", Description = "", Area = "" },
                    new { ExerciseId = 182, Name = "Wrist Flexion  - Theraband", Description = "", Area = "" },
                    new { ExerciseId = 183, Name = "Wrist Flexion  - AROM", Description = "", Area = "" },
                    new { ExerciseId = 184, Name = "Wrist Extension  - Theraband", Description = "", Area = "" },
                    new { ExerciseId = 185, Name = "Wrist Extension  - AROM", Description = "", Area = "" },
                    new { ExerciseId = 186, Name = "Wrist Ulnar Deviation  - Theraband", Description = "", Area = "" },
                    new { ExerciseId = 187, Name = "Wrist Ulnar Deviation  - AROM", Description = "", Area = "" },
                    new { ExerciseId = 188, Name = "Wrist Radial Deviation   - Theraband", Description = "", Area = "" },
                    new { ExerciseId = 189, Name = "Wrist Radial Deviation   - AROM", Description = "", Area = "" },
                    new { ExerciseId = 190, Name = "Wrist Supination  - Theraband", Description = "", Area = "" },
                    new { ExerciseId = 191, Name = "Wrist Supination  - AROM", Description = "", Area = "" },
                    new { ExerciseId = 192, Name = "Wrist Pronation  - Theraband", Description = "", Area = "" },
                    new { ExerciseId = 193, Name = "Wrist Pronation  - AROM", Description = "", Area = "" }
                );
            });
        }

        #endregion
    }
}
