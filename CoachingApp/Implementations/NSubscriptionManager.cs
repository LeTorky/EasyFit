using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class NSubscriptionManager:INSubscriptionManager
    {
        private IdentityApplicationContext _context;
        public NSubscriptionManager(IdentityApplicationContext identityApplicationContext)
        {
            _context = identityApplicationContext;
        }

        //get sub by sub id
        public async Task<Nutrition_Subscription> GetNSubByID(int id)
        {
               var nutrition_Subscription = await _context.Nutrition_Subscriptions.FindAsync(id);
            return nutrition_Subscription;
        }


        //get sub by sub id and coach id
        public async Task<bool> GetNSubByCoachID(int id,int CoachId)
        {
            var nutrition_Subscription = _context.Nutrition_Subscriptions.Where(s => s.id == id && s.coachID == CoachId);
            return nutrition_Subscription!=null?true:false;
        }

        // creat new sub
        public async Task<Nutrition_Subscription> NewNutritionSubs(int ID, int Duration,int Price, int CoachId)
        {
            var newSub = new Nutrition_Subscription() {duration=Duration,price=Price,coachID=CoachId };
            
           var subNutration= _context.Nutrition_Subscriptions.Add(newSub);
            await _context.SaveChangesAsync();

            return await this.GetNSubByID(ID);
        }

        //Delete existing sub
        public async  void DeleteNutritionSub(int id)
        {
            var nutrition_Subscription = await this.GetNSubByID(id);
            _context.Nutrition_Subscriptions.Remove(nutrition_Subscription);
            await _context.SaveChangesAsync();
        }
        // edit existing sub
        public async Task<Nutrition_Subscription> EditNutritionSubs(int ID, int Duration, int Price, int CoachId)
        {
           
          
            
                var nutrition_Subscription = await this.GetNSubByID(ID);

                nutrition_Subscription.duration= Duration;
                nutrition_Subscription.price = Price;   
            
            await _context.SaveChangesAsync();
            return nutrition_Subscription;
        }
        public async Task<Client_NSub> NewNutrRequest(int ClientId, int SubId, DateTime date, int CoachId)
        {
            Client_NSub NewEntry = new Client_NSub() { clientID = ClientId, subID = SubId, subDate = date, coachID = CoachId };
            _context.Client_NSubs.Add(NewEntry);
            await _context.SaveChangesAsync();
            return NewEntry;
        }

        public async Task<Client_NSub> NSubStatusChange(int ClientId, int SubId, DateTime Startdate, int CoachId, bool status,DateTime RequestDate)
        {
            Client_NSub Subscribation = await _context.Client_NSubs.Where(s => s.clientID == ClientId && s.subID == SubId && s.subDate == RequestDate).FirstOrDefaultAsync();
            if( Subscribation == null )
            {
                return null;
            }
            Subscribation.subDate = Startdate;
            Subscribation.accept = status;
            await _context.SaveChangesAsync();

            return Subscribation;


        }
    }
}
