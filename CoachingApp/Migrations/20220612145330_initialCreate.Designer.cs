﻿// <auto-generated />
using System;
using CoachingApp.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoachingApp.Migrations
{
    [DbContext(typeof(IdentityApplicationContext))]
    [Migration("20220612145330_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CoachingApp.Identity.IdentityApplicationRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("CoachingApp.Identity.IdentityApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CoachingApp.Models.Certificate", b =>
                {
                    b.Property<string>("name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("coachID")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("name", "coachID")
                        .HasName("PK_certificates");

                    b.HasIndex("coachID");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("CoachingApp.Models.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("country")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firstName")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<bool?>("gender")
                        .HasColumnType("bit");

                    b.Property<double?>("height")
                        .HasColumnType("float");

                    b.Property<string>("image")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("lastName")
                        .HasMaxLength(50)
                        .HasColumnType("nchar(50)")
                        .IsFixedLength();

                    b.Property<string>("mobileNum")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double?>("weight")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_Meal_NSub", b =>
                {
                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<int>("mealID")
                        .HasColumnType("int");

                    b.Property<int>("subID")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("date");

                    b.HasKey("clientID", "mealID", "subID", "date")
                        .HasName("PK_client_meal_sub");

                    b.HasIndex("mealID");

                    b.HasIndex("subID");

                    b.ToTable("Client_Meal_NSub");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_NSub", b =>
                {
                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<int>("subID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("date");

                    b.Property<bool?>("accept")
                        .HasColumnType("bit");

                    b.Property<int>("coachID")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("rating")
                        .HasColumnType("int");

                    b.HasKey("clientID", "subID", "startDate")
                        .HasName("PK_Client_coach_Nsubscription_1");

                    b.HasIndex("subID");

                    b.ToTable("Client_NSub");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_Workout_WSub", b =>
                {
                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<int>("workoutID")
                        .HasColumnType("int");

                    b.Property<int>("subID")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("date");

                    b.Property<string>("clientNotes")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("status")
                        .HasColumnType("bit");

                    b.HasKey("clientID", "workoutID", "subID", "date")
                        .HasName("PK_client_workout_sub");

                    b.HasIndex("subID");

                    b.HasIndex("workoutID");

                    b.ToTable("Client_Workout_WSub");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_WSub", b =>
                {
                    b.Property<int>("clientID")
                        .HasColumnType("int");

                    b.Property<int>("subID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("date");

                    b.Property<bool?>("accept")
                        .HasColumnType("bit");

                    b.Property<int>("coachID")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("rating")
                        .HasColumnType("int");

                    b.HasKey("clientID", "subID", "startDate")
                        .HasName("PK_Client_coach_WOsubscription_1");

                    b.HasIndex("subID");

                    b.ToTable("Client_WSub");
                });

            modelBuilder.Entity("CoachingApp.Models.Coach", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("NumberOfRating")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("country")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("firstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("gender")
                        .HasColumnType("bit");

                    b.Property<string>("image")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("lastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mobileNum")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<double?>("rating")
                        .HasColumnType("float");

                    b.Property<int?>("speciality")
                        .HasColumnType("int");

                    b.Property<int?>("yearsExperience")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("speciality");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Excercise", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("coachID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("link")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("id");

                    b.HasIndex("coachID");

                    b.ToTable("Excercise");
                });

            modelBuilder.Entity("CoachingApp.Models.Meal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("coachID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("id");

                    b.HasIndex("coachID");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("CoachingApp.Models.Nutrition_Subscription", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("coachID")
                        .HasColumnType("int");

                    b.Property<int?>("duration")
                        .HasColumnType("int");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("coachID");

                    b.ToTable("Nutrition_Subscription");
                });

            modelBuilder.Entity("CoachingApp.Models.Speciality", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("id");

                    b.ToTable("Speciality");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("coachID")
                        .HasColumnType("int");

                    b.Property<int?>("duration")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("notes")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("id");

                    b.HasIndex("coachID");

                    b.ToTable("Workout");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_Exercise", b =>
                {
                    b.Property<int>("workoutID")
                        .HasColumnType("int");

                    b.Property<int>("excerciseID")
                        .HasColumnType("int");

                    b.Property<int>("rank")
                        .HasColumnType("int");

                    b.Property<string>("notes")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("reps")
                        .HasColumnType("int");

                    b.Property<int?>("sets")
                        .HasColumnType("int");

                    b.HasKey("workoutID", "excerciseID", "rank")
                        .HasName("PK_workout_excercise");

                    b.HasIndex("excerciseID");

                    b.ToTable("Workout_Exercise");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_Subscription", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int?>("coachID")
                        .HasColumnType("int");

                    b.Property<int?>("duration")
                        .HasColumnType("int");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("coachID");

                    b.ToTable("Workout_Subscription");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_WorkoutSet", b =>
                {
                    b.Property<int>("workout_set_id")
                        .HasColumnType("int");

                    b.Property<int>("workoutID")
                        .HasColumnType("int");

                    b.Property<int>("rank")
                        .HasColumnType("int");

                    b.HasKey("workout_set_id", "workoutID")
                        .HasName("PK_workouts_in_sets_1");

                    b.HasIndex("workoutID");

                    b.ToTable("Workout_WorkoutSets");
                });

            modelBuilder.Entity("CoachingApp.Models.WorkoutSet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("coachID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.HasIndex("coachID");

                    b.ToTable("WorkoutSets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CoachingApp.Models.Certificate", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("Certificates")
                        .HasForeignKey("coachID")
                        .IsRequired()
                        .HasConstraintName("FK_certificates_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Client", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationUser", "User")
                        .WithOne("Client")
                        .HasForeignKey("CoachingApp.Models.Client", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_Meal_NSub", b =>
                {
                    b.HasOne("CoachingApp.Models.Client", "client")
                        .WithMany("Client_Meal_NSubs")
                        .HasForeignKey("clientID")
                        .IsRequired()
                        .HasConstraintName("FK_client_meal_sub_client");

                    b.HasOne("CoachingApp.Models.Meal", "meal")
                        .WithMany("Client_Meal_NSubs")
                        .HasForeignKey("mealID")
                        .IsRequired()
                        .HasConstraintName("FK_client_meal_sub_meal");

                    b.HasOne("CoachingApp.Models.Nutrition_Subscription", "sub")
                        .WithMany("Client_Meal_NSubs")
                        .HasForeignKey("subID")
                        .IsRequired()
                        .HasConstraintName("FK_client_meal_sub_nutrition_subscription");

                    b.Navigation("client");

                    b.Navigation("meal");

                    b.Navigation("sub");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_NSub", b =>
                {
                    b.HasOne("CoachingApp.Models.Client", "client")
                        .WithMany("Client_NSubs")
                        .HasForeignKey("clientID")
                        .IsRequired()
                        .HasConstraintName("FK_Client_coach_Nsubscription_client");

                    b.HasOne("CoachingApp.Models.Nutrition_Subscription", "sub")
                        .WithMany("Client_NSubs")
                        .HasForeignKey("subID")
                        .IsRequired()
                        .HasConstraintName("FK_Client_coach_Nsubscription_nutrition_subscription");

                    b.Navigation("client");

                    b.Navigation("sub");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_Workout_WSub", b =>
                {
                    b.HasOne("CoachingApp.Models.Client", "client")
                        .WithMany("Client_Workout_WSubs")
                        .HasForeignKey("clientID")
                        .IsRequired()
                        .HasConstraintName("FK_client_workout_sub_client");

                    b.HasOne("CoachingApp.Models.Workout_Subscription", "sub")
                        .WithMany("Client_Workout_WSubs")
                        .HasForeignKey("subID")
                        .IsRequired()
                        .HasConstraintName("FK_client_workout_sub_Workout_Subscription");

                    b.HasOne("CoachingApp.Models.Workout", "workout")
                        .WithMany("Client_Workout_WSubs")
                        .HasForeignKey("workoutID")
                        .IsRequired()
                        .HasConstraintName("FK_client_workout_sub_Workout");

                    b.Navigation("client");

                    b.Navigation("sub");

                    b.Navigation("workout");
                });

            modelBuilder.Entity("CoachingApp.Models.Client_WSub", b =>
                {
                    b.HasOne("CoachingApp.Models.Client", "client")
                        .WithMany("Client_WSubs")
                        .HasForeignKey("clientID")
                        .IsRequired()
                        .HasConstraintName("FK_Client_coach_WOsubscription_client");

                    b.HasOne("CoachingApp.Models.Workout_Subscription", "sub")
                        .WithMany("Client_WSubs")
                        .HasForeignKey("subID")
                        .IsRequired()
                        .HasConstraintName("FK_Client_coach_WOsubscription_Workout_Subscription");

                    b.Navigation("client");

                    b.Navigation("sub");
                });

            modelBuilder.Entity("CoachingApp.Models.Coach", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationUser", "User")
                        .WithOne("Coach")
                        .HasForeignKey("CoachingApp.Models.Coach", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingApp.Models.Speciality", "specialityNavigation")
                        .WithMany("Coaches")
                        .HasForeignKey("speciality")
                        .HasConstraintName("FK_Coach_Speciality");

                    b.Navigation("User");

                    b.Navigation("specialityNavigation");
                });

            modelBuilder.Entity("CoachingApp.Models.Excercise", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("Excercises")
                        .HasForeignKey("coachID")
                        .IsRequired()
                        .HasConstraintName("FK_Excercise_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Meal", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("Meals")
                        .HasForeignKey("coachID")
                        .IsRequired()
                        .HasConstraintName("FK_meal_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Nutrition_Subscription", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("Nutrition_Subscriptions")
                        .HasForeignKey("coachID")
                        .HasConstraintName("FK_nutrition_subscription_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("Workouts")
                        .HasForeignKey("coachID")
                        .HasConstraintName("FK_Workout_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_Exercise", b =>
                {
                    b.HasOne("CoachingApp.Models.Excercise", "excercise")
                        .WithMany("Workout_Exercises")
                        .HasForeignKey("excerciseID")
                        .IsRequired()
                        .HasConstraintName("FK_workout_excercise_Excercise");

                    b.HasOne("CoachingApp.Models.Workout", "workout")
                        .WithMany("Workout_Exercises")
                        .HasForeignKey("workoutID")
                        .IsRequired()
                        .HasConstraintName("FK_workout_excercise_Workout");

                    b.Navigation("excercise");

                    b.Navigation("workout");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_Subscription", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("Workout_Subscriptions")
                        .HasForeignKey("coachID")
                        .HasConstraintName("FK_Workout_Subscription_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_WorkoutSet", b =>
                {
                    b.HasOne("CoachingApp.Models.Workout", "workout")
                        .WithMany("Workout_WorkoutSets")
                        .HasForeignKey("workoutID")
                        .IsRequired()
                        .HasConstraintName("FK_workouts_in_sets_Workout");

                    b.HasOne("CoachingApp.Models.WorkoutSet", "workout_set")
                        .WithMany("Workout_WorkoutSets")
                        .HasForeignKey("workout_set_id")
                        .IsRequired()
                        .HasConstraintName("FK_workouts_in_sets_Workout_Sets");

                    b.Navigation("workout");

                    b.Navigation("workout_set");
                });

            modelBuilder.Entity("CoachingApp.Models.WorkoutSet", b =>
                {
                    b.HasOne("CoachingApp.Models.Coach", "coach")
                        .WithMany("WorkoutSets")
                        .HasForeignKey("coachID")
                        .HasConstraintName("FK_Workout_Sets_coach");

                    b.Navigation("coach");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoachingApp.Identity.IdentityApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CoachingApp.Identity.IdentityApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoachingApp.Identity.IdentityApplicationUser", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("CoachingApp.Models.Client", b =>
                {
                    b.Navigation("Client_Meal_NSubs");

                    b.Navigation("Client_NSubs");

                    b.Navigation("Client_WSubs");

                    b.Navigation("Client_Workout_WSubs");
                });

            modelBuilder.Entity("CoachingApp.Models.Coach", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Excercises");

                    b.Navigation("Meals");

                    b.Navigation("Nutrition_Subscriptions");

                    b.Navigation("WorkoutSets");

                    b.Navigation("Workout_Subscriptions");

                    b.Navigation("Workouts");
                });

            modelBuilder.Entity("CoachingApp.Models.Excercise", b =>
                {
                    b.Navigation("Workout_Exercises");
                });

            modelBuilder.Entity("CoachingApp.Models.Meal", b =>
                {
                    b.Navigation("Client_Meal_NSubs");
                });

            modelBuilder.Entity("CoachingApp.Models.Nutrition_Subscription", b =>
                {
                    b.Navigation("Client_Meal_NSubs");

                    b.Navigation("Client_NSubs");
                });

            modelBuilder.Entity("CoachingApp.Models.Speciality", b =>
                {
                    b.Navigation("Coaches");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout", b =>
                {
                    b.Navigation("Client_Workout_WSubs");

                    b.Navigation("Workout_Exercises");

                    b.Navigation("Workout_WorkoutSets");
                });

            modelBuilder.Entity("CoachingApp.Models.Workout_Subscription", b =>
                {
                    b.Navigation("Client_WSubs");

                    b.Navigation("Client_Workout_WSubs");
                });

            modelBuilder.Entity("CoachingApp.Models.WorkoutSet", b =>
                {
                    b.Navigation("Workout_WorkoutSets");
                });
#pragma warning restore 612, 618
        }
    }
}