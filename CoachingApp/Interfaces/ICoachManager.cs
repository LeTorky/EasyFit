using CoachingApp.DTO;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface ICoachManager
    {
        public Coach CreateCoach(CoachUserDTO CoachUser, Guid UserId);
        public bool isCoach(int id);

    }
}
