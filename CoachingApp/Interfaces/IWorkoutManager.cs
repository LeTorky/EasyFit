using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IWorkoutManager
    {
        public Task<Workout> addWorkout(Workout workout);
        public bool workoutExists(int workoutID);
        public bool workoutExists(string name, int coachid);
        public Workout updateWorkout(int workoutid, Workout workout);
        public Client_Workout_WSub updateWorkoutStatus(int workoutID, int clientID, int subID, DateTime woDate, int status, string clientNotes);
        public List<Workout> getWorkoutsByCoachId(int coachId);
        public bool deleteWorkOut(int coachId, int workoutId);
        public List<Workout> getWorkoutByClientSub(int ClientId, int subId);
        public List<Workout> getWorkoutByClientSubCoach(int CoachId, int ClientId, int subId);
        public bool addWorkOutToClientSub(int WorkoutId, int ClientId, int subId, int CoachId, string Notes);
        public bool removeWorkOutFromClientSub(int WorkoutId, int ClientId, int subId, int CoachId);
    }
}
