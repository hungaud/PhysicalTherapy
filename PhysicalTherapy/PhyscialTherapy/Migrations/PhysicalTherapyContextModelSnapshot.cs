﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhysicalTherapy.Models;

namespace PhysicalTherapy.Migrations
{
    [DbContext(typeof(PhysicalTherapyContext))]
    partial class PhysicalTherapyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhysicalTherapy.Models.AccountType", b =>
                {
                    b.Property<int>("AccountTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountTypeId");

                    b.Property<string>("Bio");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("AdministratorId");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Administrations");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Credential", b =>
                {
                    b.Property<int>("CredentialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("CredentialId");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Excercise", b =>
                {
                    b.Property<int>("ExcerciseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ExcerciseId");

                    b.ToTable("Excercises");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.MessageLog", b =>
                {
                    b.Property<int>("MessageLogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertDate");

                    b.Property<string>("Message");

                    b.Property<int>("PatientId");

                    b.Property<int>("RoutineId");

                    b.Property<int>("TherapistId");

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

                    b.Property<int>("AccountTypeId");

                    b.Property<string>("Bio");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("TherapistId");

                    b.HasKey("PatientId");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("TherapistId");

                    b.ToTable("Patients");
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

                    b.Property<int>("PatientId");

                    b.Property<int?>("PostRoutineSurveyId");

                    b.Property<bool>("isNew");

                    b.HasKey("RoutineId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PostRoutineSurveyId");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.RoutineExercise", b =>
                {
                    b.Property<int>("RoutineExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExcersiseExcerciseId");

                    b.Property<string>("ExerciseId");

                    b.Property<int?>("FrequencyPerDay");

                    b.Property<decimal?>("HoldLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Notes");

                    b.Property<int?>("Rep");

                    b.Property<int>("RoutineId");

                    b.Property<int?>("Sets");

                    b.HasKey("RoutineExerciseId");

                    b.HasIndex("ExcersiseExcerciseId");

                    b.HasIndex("RoutineId");

                    b.ToTable("RoutineExercises");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Therapist", b =>
                {
                    b.Property<int>("TherapistId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountTypeId");

                    b.Property<string>("Bio");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("TherapistId");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Therapists");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Administrator", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhysicalTherapy.Models.MessageLog", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhysicalTherapy.Models.Routine", "Routine")
                        .WithMany()
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhysicalTherapy.Models.Therapist", "Therapist")
                        .WithMany()
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Patient", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhysicalTherapy.Models.Therapist", "Therapist")
                        .WithMany("Patients")
                        .HasForeignKey("TherapistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Routine", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PhysicalTherapy.Models.PostRoutineSurvey", "PostRoutineSurvey")
                        .WithMany()
                        .HasForeignKey("PostRoutineSurveyId");
                });

            modelBuilder.Entity("PhysicalTherapy.Models.RoutineExercise", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.Excercise", "Excersise")
                        .WithMany()
                        .HasForeignKey("ExcersiseExcerciseId");

                    b.HasOne("PhysicalTherapy.Models.Routine", "Routine")
                        .WithMany("RoutineExercises")
                        .HasForeignKey("RoutineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhysicalTherapy.Models.Therapist", b =>
                {
                    b.HasOne("PhysicalTherapy.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
