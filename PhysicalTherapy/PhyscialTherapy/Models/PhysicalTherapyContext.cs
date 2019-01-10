using Microsoft.EntityFrameworkCore;
using PhysicalTherapy.Models;
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

        public DbSet<AccountType> AccountTypes { get; set; }
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
                entity.HasOne(a => a.AccountType);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne(a => a.AccountType);
            });

            modelBuilder.Entity<MessageLog>(entity =>
            {
                entity.HasOne(p => p.Patient);
                entity.HasOne(r => r.Routine)
                    .WithMany(ml => ml.ListOfMessageLogs)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(t => t.Therapist);
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
                entity.HasOne(a => a.AccountType);
            });

            SeedAccountType(modelBuilder);
            SeedExercise(modelBuilder);
        }

        private void SeedAccountType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>(a =>
            {
                a.HasData
                (
                    new { AccountTypeId = 1, Name = "Admin" },
                    new { AccountTypeId = 2, Name = "Therapist" },
                    new { AccountTypeId = 3, Name = "Patient" }
                );
            });
        }

        private void SeedExercise(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(e =>
            {
                e.HasData
                (
                    new { ExerciseId = 1, Name = "Quad Sets", Description = "", Area = "Knee" },
                    new { ExerciseId = 2, Name = "Knee Slides with Towel", Description = "", Area = "Knee" },
                    new { ExerciseId = 3, Name = "Prone Knee Hang", Description = "", Area = "Knee" },
                    new { ExerciseId = 4, Name = "Step Knee Flexion", Description = "", Area = "Knee" },
                    new { ExerciseId = 5, Name = "Calf Stretch", Description = "", Area = "Knee" },
                    new { ExerciseId = 6, Name = "Hamstring Stretch", Description = "", Area = "Knee" },
                    new { ExerciseId = 7, Name = "Ice to Knee with Elevation", Description = "", Area = "Knee" }
                );
            });
        }
    }


}
