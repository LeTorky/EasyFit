using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class WSubscriptionManager : IWSubscriptionManager
    {
        private IdentityApplicationContext _context;
        public WSubscriptionManager(IdentityApplicationContext identityApplicationContext)
        {
            _context = identityApplicationContext;
        }
        public async Task<Workout_Subscription> GetWSubByID(int id)
        {
            var workout_Subscription = await _context.Workout_Subscriptions.FindAsync(id);
            return workout_Subscription;
        }
        public async void DeleteWorkoutSub(int id)
        {
            var workoutSubscription = await this.GetWSubByID(id);
            _context.Workout_Subscriptions.Remove(workoutSubscription);
            await _context.SaveChangesAsync();
        }

        public async void EditWorkoutSubs(Workout_Subscription workout_Subscription)
        {
            
            _context.Workout_Subscriptions.Remove(workout_Subscription);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> NewWorkoutSubs(Workout_Subscription workout_Subscription)
        {
            var subworkout = _context.Workout_Subscriptions.Add(workout_Subscription);
            await _context.SaveChangesAsync();

            return subworkout == null ? true : false;
        }
        

        public Workout_Subscription getSubscription(int subid)
        {
            return _context.Workout_Subscriptions.Find(subid);
        }
    }
}
