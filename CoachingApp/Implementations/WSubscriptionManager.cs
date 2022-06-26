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
        //get sub by sub id
        public async Task<Workout_Subscription> GetWSubByID(int id)
        {
            var workout_Subscription = await _context.Workout_Subscriptions.FindAsync(id);
            return workout_Subscription;
        }


        //get sub by sub id and coach id
        public async Task<bool> GetWSubByCoachID(int id, int CoachId)
        {
            var workout_Subscription = _context.Workout_Subscriptions.Where(s => s.id == id && s.coachID == CoachId);
            return workout_Subscription != null ? true : false;
        }

        // creat new sub
        public async Task<Workout_Subscription> NewWorkoutSubs(int ID, int Duration, int Price, int CoachId)
        {
            var newSub = new Workout_Subscription() {id=ID, duration = Duration, price = Price, coachID = CoachId };

            var subNutration = _context.Workout_Subscriptions.Add(newSub);
            await _context.SaveChangesAsync();

            return await this.GetWSubByID(ID);
        }

        //Delete existing sub
        public async void DeleteWorkoutSub(int id)
        {
            var workout_Subscription = await this.GetWSubByID(id);
            _context.Workout_Subscriptions.Remove(workout_Subscription);
            await _context.SaveChangesAsync();
        }
        // edit existing sub
        public async Task<Workout_Subscription> EditWorkoutSubs(int ID, int Duration, int Price, int CoachId)
        {



            var workout_Subscription = await this.GetWSubByID(ID);

            workout_Subscription.duration = Duration;
            workout_Subscription.price = Price;

            await _context.SaveChangesAsync();
            return workout_Subscription;
        }
        public async Task<Client_WSub> NewWorkoutSubRequest(int ClientId, int SubId, DateTime date, int CoachId)
        {
            Client_WSub NewEntry = new Client_WSub() { clientID = ClientId, subID = SubId, startDate = date, coachID = CoachId };
            _context.Client_WSubs.Add(NewEntry);
            await _context.SaveChangesAsync();
            return NewEntry;
        }

        public async Task<Client_WSub> WSubStatusChange(int ClientId, int SubId, DateTime Startdate, int CoachId, bool status, DateTime RequestDate)
        {
            Client_WSub Subscribation = await _context.Client_WSubs.Where(s => s.clientID == ClientId && s.subID == SubId && s.startDate == RequestDate).FirstOrDefaultAsync();
            if (Subscribation == null)
            {
                return null;
            }
            Subscribation.startDate = Startdate;
            Subscribation.accept = status;
            await _context.SaveChangesAsync();

            return Subscribation;


        }


        public Workout_Subscription getSubscription(int subid)
        {
            return _context.Workout_Subscriptions.Find(subid);
        }
    }
}
