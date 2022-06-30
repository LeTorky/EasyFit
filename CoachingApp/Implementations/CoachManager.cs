using CoachingApp.DTO;
using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Implementations
{
    public class CoachManager:ICoachManager
    {
        private IdentityApplicationContext _identityApplicationContext;
        public CoachManager(IdentityApplicationContext identityApplicationContext)
        {
            _identityApplicationContext = identityApplicationContext;
        }
        public Coach CreateCoach(CoachUserDTO CoachUser, Guid UserId)
        {
            Coach NewCoach = new Coach()
            {
                UserId = UserId,
                firstName = CoachUser.firstName,
                lastName = CoachUser.lastName,
                age = CoachUser.age,
                mobileNum = CoachUser.mobileNum,
                about = CoachUser.about,
                gender = CoachUser.gender,
                city = CoachUser.city,
                country = CoachUser.country,
                yearsExperience = CoachUser.yearsExperience,
                speciality = CoachUser.speciality,
            };
            _identityApplicationContext.Coaches.Add(NewCoach);
            _identityApplicationContext.SaveChanges();
            return NewCoach;
        }
        public bool isCoach(int id)
        {
            return _identityApplicationContext.Coaches.Any(c=>c.id == id);
        }
    }
}
