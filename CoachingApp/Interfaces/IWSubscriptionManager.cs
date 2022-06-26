using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IWSubscriptionManager
    {
        public Task<Workout_Subscription> GetWSubByID(int id);
        public Task<Workout_Subscription> NewWorkoutSubs(int ID, int Duration, int Price, int CoachId);
        public Task<Workout_Subscription> EditWorkoutSubs(int ID, int Duration, int Price, int CoachId);
        public void DeleteWorkoutSub(int id);
        public Task<bool> GetWSubByCoachID(int id, int CoachId);
        public Task<Client_WSub> NewWorkoutSubRequest(int ClientId, int SubId, DateTime date, int CoachId);
        public Task<Client_WSub> WSubStatusChange(int ClientId, int SubId, DateTime Startdate, int CoachId, bool status, DateTime RequestDate);
        public Workout_Subscription getSubscription(int subid);

    }
}
