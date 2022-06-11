using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface ICoachManager
    {
        public object GetCoachById(int id);
        public List<Coach> GetAllCoaches();
        public List<Coach> DeleteCoach();
        public List<Coach> UpdateCoach();
        public List<Coach> GetCoachProfile();
    }
}
