using CoachingApp.Identity;
using CoachingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace CoachingApp.Implementations
{
    public partial class IdentityApplicationContext : IdentityDbContext<IdentityApplicationUser, IdentityApplicationRoles, Guid>
    {
        public IdentityApplicationContext(DbContextOptions<IdentityApplicationContext> options) : base(options) 
        {
            // Constructing with connection string via DI.
        }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Client_Meal_NSub> Client_Meal_NSubs { get; set; }
        public virtual DbSet<Client_NSub> Client_NSubs { get; set; }
        public virtual DbSet<Client_WSub> Client_WSubs { get; set; }
        public virtual DbSet<Client_Workout_WSub> Client_Workout_WSubs { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Excercise> Excercises { get; set; }
        public virtual DbSet<Meal> Meals { get; set; }
        public virtual DbSet<Nutrition_Subscription> Nutrition_Subscriptions { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<WorkoutSet> WorkoutSets { get; set; }
        public virtual DbSet<Workout_Exercise> Workout_Exercises { get; set; }
        public virtual DbSet<Workout_Subscription> Workout_Subscriptions { get; set; }
        public virtual DbSet<Workout_WorkoutSet> Workout_WorkoutSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(e => new { e.name, e.coachID })
                    .HasName("PK_certificates");

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.coachID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_certificates_coach");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.firstName).IsFixedLength();

                entity.Property(e => e.lastName).IsFixedLength();
            });

            modelBuilder.Entity<Client_Meal_NSub>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.mealID, e.subID, e.date })
                    .HasName("PK_client_meal_sub");

                entity.HasOne(d => d.client)
                    .WithMany(p => p.Client_Meal_NSubs)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_meal_sub_client");

                entity.HasOne(d => d.meal)
                    .WithMany(p => p.Client_Meal_NSubs)
                    .HasForeignKey(d => d.mealID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_meal_sub_meal");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.Client_Meal_NSubs)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_meal_sub_nutrition_subscription");
            });

            modelBuilder.Entity<Client_NSub>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.subID, e.subDate })
                    .HasName("PK_Client_coach_Nsubscription_1");

                entity.HasOne(d => d.client)
                    .WithMany(p => p.Client_NSubs)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_Nsubscription_client");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.Client_NSubs)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_Nsubscription_nutrition_subscription");
            });

            modelBuilder.Entity<Client_WSub>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.subID, e.startDate })
                    .HasName("PK_Client_coach_WOsubscription_1");

                entity.HasOne(d => d.client)
                    .WithMany(p => p.Client_WSubs)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_WOsubscription_client");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.Client_WSubs)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_coach_WOsubscription_Workout_Subscription");
            });

            modelBuilder.Entity<Client_Workout_WSub>(entity =>
            {
                entity.HasKey(e => new { e.clientID, e.workoutID, e.subID, e.date })
                    .HasName("PK_client_workout_sub");

                entity.HasOne(d => d.client)
                    .WithMany(p => p.Client_Workout_WSubs)
                    .HasForeignKey(d => d.clientID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_workout_sub_client");

                entity.HasOne(d => d.sub)
                    .WithMany(p => p.Client_Workout_WSubs)
                    .HasForeignKey(d => d.subID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_workout_sub_Workout_Subscription");

                entity.HasOne(d => d.workout)
                    .WithMany(p => p.Client_Workout_WSubs)
                    .HasForeignKey(d => d.workoutID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_workout_sub_Workout");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasOne(d => d.specialityNavigation)
                    .WithMany(p => p.Coaches)
                    .HasForeignKey(d => d.speciality)
                    .HasConstraintName("FK_Coach_Speciality");
            });

            modelBuilder.Entity<Excercise>(entity =>
            {
                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Excercises)
                    .HasForeignKey(d => d.coachID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Excercise_coach");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.coachID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_meal_coach");
            });

            modelBuilder.Entity<Nutrition_Subscription>(entity =>
            {
                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Nutrition_Subscriptions)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_nutrition_subscription_coach");
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Workout_coach");
            });

            modelBuilder.Entity<WorkoutSet>(entity =>
            {
                entity.HasOne(d => d.coach)
                    .WithMany(p => p.WorkoutSets)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Workout_Sets_coach");
            });

            modelBuilder.Entity<Workout_Exercise>(entity =>
            {
                entity.HasKey(e => new { e.workoutID, e.excerciseID, e.rank })
                    .HasName("PK_workout_excercise");

                entity.HasOne(d => d.excercise)
                    .WithMany(p => p.Workout_Exercises)
                    .HasForeignKey(d => d.excerciseID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workout_excercise_Excercise");

                entity.HasOne(d => d.workout)
                    .WithMany(p => p.Workout_Exercises)
                    .HasForeignKey(d => d.workoutID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workout_excercise_Workout");
            });

            modelBuilder.Entity<Workout_Subscription>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.HasOne(d => d.coach)
                    .WithMany(p => p.Workout_Subscriptions)
                    .HasForeignKey(d => d.coachID)
                    .HasConstraintName("FK_Workout_Subscription_coach");
            });

            modelBuilder.Entity<Workout_WorkoutSet>(entity =>
            {
                entity.HasKey(e => new { e.workout_set_id, e.workoutID })
                    .HasName("PK_workouts_in_sets_1");

                entity.HasOne(d => d.workout)
                    .WithMany(p => p.Workout_WorkoutSets)
                    .HasForeignKey(d => d.workoutID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workouts_in_sets_Workout");

                entity.HasOne(d => d.workout_set)
                    .WithMany(p => p.Workout_WorkoutSets)
                    .HasForeignKey(d => d.workout_set_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_workouts_in_sets_Workout_Sets");
            });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
    }
}
