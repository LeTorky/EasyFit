using CoachingApp.Models;

namespace CoachingApp.DTO
{
    public class WorkoutWithDateDto
    {
        public Workout workout { get; set; }
        public DateTime workoutDate { get; set; }
    }
}
