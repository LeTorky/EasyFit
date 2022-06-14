using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IWSubscriptionManager
    {
        public Task<Workout_Subscription> GetWSubByID(int id);
        public Task<bool> NewWorkoutSubs(Workout_Subscription workout_Subscription);
        public void EditWorkoutSubs(Workout_Subscription workout_Subscription);
        public void DeleteWorkoutSub(int id);
        public Workout_Subscription getSubscription(int subid);

    }
}
