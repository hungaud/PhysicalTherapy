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
                entity.HasOne(p => p.Therapist)
                    .WithMany(t => t.ListOfPatients)
                    .HasForeignKey(fk => fk.TherapistId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .IsRequired(false);
            });

            modelBuilder.Entity<MessageLog>(entity =>
            {
                entity.HasOne(p => p.Patient);
                entity.HasOne(r => r.Routine);
                entity.HasOne(t => t.Therapist);
            });

            modelBuilder.Entity<PostRoutineSurvey>(entity =>
            {
                entity.HasOne(r => r.Routine)
                    .WithOne(prs => prs.PostRoutineSurvey)
                    .HasForeignKey<Routine>(fk => fk.RoutineId);
                    
            });

            modelBuilder.Entity<Routine>(entity =>
            {
                entity.HasOne(p => p.Patient);
                entity.HasOne(p => p.PostRoutineSurvey)
                    .WithOne(r => r.Routine)
                    .HasForeignKey<PostRoutineSurvey>(fk => fk.PostRoutineSurveyId);
                entity.HasMany(re => re.RoutineExercises)
                    .WithOne(r => r.Routine);

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
                entity.HasMany(p => p.ListOfPatients)
                    .WithOne(t => t.Therapist)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
