using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IWSubscriptionManager
    {
        public Workout_Subscription getSubscription(int subid);

    }
}
