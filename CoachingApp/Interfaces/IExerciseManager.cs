using CoachingApp.Identity;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IExerciseManager
    {
        public Excercise UpdateExcersise(int id, Excercise excersise);
        public Excercise DeleteExcercice(int id);

        public List<Excercise> GetAllExcercises();

        public List<Excercise> GetAllExcercisesForCoach(Coach User);
        public Excercise AddExcersise(Excercise excersise, int coachid);
        public List<Workout_Exercise> getExcerciseByWorkOutId(int ClientId, int WorkoutId, int SubId);
    }
}
