using CoachingApp.Identity;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface ICoachManager
    {
        public object GetCoachById(int id);
        public List<Coach> GetAllCoaches();
        public Coach DeleteCoach(int id);
        public Coach UpdateCoach(int id, Coach Coach);
        public Coach GetCoachProfile(IdentityApplicationUser User);
    }
}
