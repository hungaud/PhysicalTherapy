using Microsoft.EntityFrameworkCore;
using PhyscialTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class PhysicalTherapyContext : DbContext
    {

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PostRoutineSurvey> PostRoutineSurveys { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<RoutineExercise> RoutineExercises { get; set; }
        public DbSet<Therapist> Therapists { get; set; }

    }
}
