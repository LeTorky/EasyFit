﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoachingApp.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Models
{
    [Table("Coach")]
    public partial class Coach
    {
        public Coach()
        {
            Certificates = new HashSet<Certificate>();
            Excercises = new HashSet<Excercise>();
            Meals = new HashSet<Meal>();
            Nutrition_Subscriptions = new HashSet<Nutrition_Subscription>();
            WorkoutSets = new HashSet<WorkoutSet>();
            Workout_Subscriptions = new HashSet<Workout_Subscription>();
            Workouts = new HashSet<Workout>();
        }

        [Key]
        public int id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public int age { get; set; }
        [StringLength(50)]
        public string lastName { get; set; }
        [StringLength(50)]
        public string firstName { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string mobileNum { get; set; }
        public bool? gender { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string city { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string country { get; set; }
        public int? yearsExperience { get; set; }
        public double? rating { get; set; }
        public int? NumberOfRating { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string image { get; set; }
        [StringLength(250)]
        public string about { get; set; }
        public virtual IdentityApplicationUser User { get; set; }

        public int? speciality { get; set; }

        [ForeignKey("speciality")]
        [InverseProperty("Coaches")]
        public virtual Speciality specialityNavigation { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Certificate> Certificates { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Excercise> Excercises { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Meal> Meals { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Nutrition_Subscription> Nutrition_Subscriptions { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<WorkoutSet> WorkoutSets { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Workout_Subscription> Workout_Subscriptions { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Workout> Workouts { get; set; }
        [InverseProperty("coach")]
        public virtual ICollection<Client_WSub> Client_WSubs { get; set; }
    }
}