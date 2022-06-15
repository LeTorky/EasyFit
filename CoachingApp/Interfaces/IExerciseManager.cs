using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IExerciseManager
    {
        Task CreateExcercise(Excercise obj);
    }
}
