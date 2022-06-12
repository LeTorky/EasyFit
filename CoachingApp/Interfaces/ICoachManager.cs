using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface ICoachManager
    {
        public object GetCoachById(int id);
        public List<Coach> GetAllCoaches();
        public List<Coach> DeleteCoach();
        public Coach UpdateCoach(int id, Coach Coach);
        public List<Coach> GetCoachProfile();
    }
}
