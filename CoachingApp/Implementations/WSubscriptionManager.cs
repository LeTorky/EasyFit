using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Implementations
{
    public class WSubscriptionManager : IWSubscriptionManager
    {
        private readonly IdentityApplicationContext _context;

        public WSubscriptionManager(IdentityApplicationContext context)
        {
            _context = context;
        }

        public Workout_Subscription getSubscription(int subid)
        {
            return _context.Workout_Subscriptions.Find(subid);
        }
    }
}
