﻿using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IWorkoutManager
    {
        public Task<Workout> addWorkout(Workout workout);
        public bool workoutExists(int workoutID);
        public bool workoutExists(string name, int coachid);
        public Workout updateWorkout(int workoutid, Workout workout);
        public Client_Workout_WSub updateWorkoutStatus(int workoutID, int clientID, int subID, DateTime woDate, int status, string clientNotes);

    }
}
