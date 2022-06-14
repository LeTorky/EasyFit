using CoachingApp.DTO;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IWorkoutSetsManager
    {
        public IEnumerable<WorkoutSet> getWorkoutsByCoachID(int coachID);
        public Task<WorkoutSet> addWorkoutSet(WorkoutSet workoutSet);
        public bool setExists(int Setid);
        public bool setExists(string name, int coachid);
        public Task<WorkoutSet> updateWorkoutSet(int Setid, WorkoutSet workoutSet);
        public Task<WorkoutSet> deleteWorkoutSet(int Setid);
        public Task<WorkoutSet> getWorkoutSet(int setid);
        public IEnumerable<Client_Workout_WSub> assignWorkoutsToClient(int coachid, int clientid, int subid, IEnumerable<WorkoutWithDateDto> workouts);
    }
}
