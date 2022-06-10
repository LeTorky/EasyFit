using CoachingApp.Identity;
using CoachingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace CoachingApp.Implementations
{
    public partial class IdentityApplicationContext : IdentityDbContext<IdentityApplicationUser>
    {
        public IdentityApplicationContext(DbContextOptions<IdentityApplicationContext> options) : base(options) 
        {
            // Constructing with connection string via DI.
        }
        public virtual DbSet<Client_coach_Nsubscription> Client_coach_Nsubscriptions { get; set; }
        public virtual DbSet<Client_coach_WOsubscription> Client_coach_WOsubscriptions { get; set; }
        public virtual DbSet<Excercise> Excercises { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<Workout_Set> Workout_Sets { get; set; }
        public virtual DbSet<Workout_Subscription> Workout_Subscriptions { get; set; }
        public virtual DbSet<certificate> certificates { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<client_meal_sub> client_meal_subs { get; set; }
        public virtual DbSet<client_workout_sub> client_workout_subs { get; set; }
        public virtual DbSet<coach> coaches { get; set; }
        public virtual DbSet<meal> meals { get; set; }
        public virtual DbSet<nutrition_subscription> nutrition_subscriptions { get; set; }
        public virtual DbSet<workout_excercise> workout_excercises { get; set; }
        public virtual DbSet<workouts_in_set> workouts_in_sets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client_coach_Nsubscription>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.coachID, e.subID, e.startDate });

                entity.HasOne(d => d.client)
                    .WithMany(p => p.Client_coach_Nsubscriptions)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_Nsubscription_client");

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Client_coach_Nsubscriptions)
                    .HasForeignKey(d => d.coachID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_Nsubscription_coach");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.Client_coach_Nsubscriptions)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_Nsubscription_nutrition_subscription");
            });

            modelBuilder.Entity<Client_coach_WOsubscription>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.coachID, e.subID, e.startDate });

                entity.HasOne(d => d.client)
                    .WithMany(p => p.Client_coach_WOsubscriptions)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_WOsubscription_client");

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Client_coach_WOsubscriptions)
                    .HasForeignKey(d => d.coachID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_WOsubscription_coach");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.Client_coach_WOsubscriptions)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_WOsubscription_Workout_Subscription");
            });

            modelBuilder.Entity<Excercise>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Excercises)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Excercise_coach");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Workout_coach");
            });

            modelBuilder.Entity<Workout_Set>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Workout_Sets)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Workout_Sets_coach");
            });

            modelBuilder.Entity<Workout_Subscription>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Workout_Subscriptions)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Workout_Subscription_coach");
            });

            modelBuilder.Entity<certificate>(entity =>
            {
                entity.HasKey(e => new { e.name, e.coachID });

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.certificates)
                    .HasForeignKey(d => d.coachID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_certificates_coach");
            });

            modelBuilder.Entity<client>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.firstName).IsFixedLength();

                entity.Property(e => e.lastName).IsFixedLength();
            });

            modelBuilder.Entity<client_meal_sub>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.mealID, e.subID, e.date });

                entity.HasOne(d => d.client)
                    .WithMany(p => p.client_meal_subs)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_meal_sub_client");

                entity.HasOne(d => d.meal)
                    .WithMany(p => p.client_meal_subs)
                    .HasForeignKey(d => d.mealID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_meal_sub_meal");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.client_meal_subs)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_meal_sub_nutrition_subscription");
            });

            modelBuilder.Entity<client_workout_sub>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.workoutID, e.subID, e.date });

                entity.HasOne(d => d.client)
                    .WithMany(p => p.client_workout_subs)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_workout_sub_client");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.client_workout_subs)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_workout_sub_Workout_Subscription");

                entity.HasOne(d => d.workout)
                    .WithMany(p => p.client_workout_subs)
                    .HasForeignKey(d => d.workoutID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_workout_sub_Workout");
            });

            modelBuilder.Entity<coach>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();
            });

            modelBuilder.Entity<meal>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.meals)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_meal_coach");
            });

            modelBuilder.Entity<nutrition_subscription>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.nutrition_subscriptions)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_nutrition_subscription_coach");
            });

            modelBuilder.Entity<workout_excercise>(entity =>
            {
                entity.HasKey(e => new { e.workoutID, e.excerciseID });

                entity.HasOne(d => d.excercise)
                    .WithMany(p => p.workout_excercises)
                    .HasForeignKey(d => d.excerciseID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workout_excercise_Excercise");

                entity.HasOne(d => d.workout)
                    .WithMany(p => p.workout_excercises)
                    .HasForeignKey(d => d.workoutID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workout_excercise_Workout");
            });

            modelBuilder.Entity<workouts_in_set>(entity =>
            {
                entity.HasKey(e => new { e.workout_set_id, e.workoutID })
                    .HasName("PK_workouts_in_sets_1");

                entity.HasOne(d => d.workout)
                    .WithMany(p => p.workouts_in_sets)
                    .HasForeignKey(d => d.workoutID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workouts_in_sets_Workout");

                entity.HasOne(d => d.workout_set)
                    .WithMany(p => p.workouts_in_sets)
                    .HasForeignKey(d => d.workout_set_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workouts_in_sets_Workout_Sets");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
