using CoachingApp.DTO;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface ICoachManager
    {
        public Coach CreateCoach(CoachUserDTO CoachUser, Guid UserId);
        public bool isCoach(int id);
        public  Task<IEnumerable<Client_WSub>> GetallCoachWsub(int id);
        public  Task<IEnumerable<Client_NSub>> GetallCoachNsub(int id);
        public  Task<Coach> GetCoachByID(int ID);

    }
}
