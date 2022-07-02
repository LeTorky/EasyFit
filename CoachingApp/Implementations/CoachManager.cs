using CoachingApp.DTO;
using CoachingApp.Controllers;
using CoachingApp.Identity;
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

        public object GetCoachById(int id)
        {
            //var GetCoach = context.Coaches.Where(c => c.id == id).Select(s => new Coach{id= s.id,age= s.age,Certificates= s.Certificates,email= s.email,Workout_Subscriptions= s.Workout_Subscriptions});
            var GetCoach = _identityApplicationContext.Coaches.Where(c => c.id == id).Select(s => new { s.id ,s.firstName,s.lastName , s.age, s.Certificates});

            return GetCoach;
        }

        public List<Coach> GetAllCoaches()
        {
            var GetCoachs = _identityApplicationContext.Coaches.ToList();
            return GetCoachs;
        }

        public Coach DeleteCoach(int id)
        {
            var CoachData = _identityApplicationContext.Coaches.Where(e => e.id == id).SingleOrDefault();
            if (CoachData != null)
                _identityApplicationContext.Coaches.Remove(CoachData);

            _identityApplicationContext.SaveChanges();
            return CoachData;
        }
        public Coach UpdateCoach(int id,Coach Coach)
        {
            Coach OldCoach = _identityApplicationContext.Coaches.Where(c => c.id == id).SingleOrDefault();

            if (OldCoach != null)
            {
                OldCoach.mobileNum = Coach.mobileNum;
                OldCoach.city = Coach.city;
                OldCoach.country = Coach.country;
                OldCoach.age = Coach.age;
                OldCoach.firstName = Coach.firstName;
                OldCoach.lastName = Coach.lastName;
                OldCoach.gender = Coach.gender;
                OldCoach.yearsExperience = Coach.yearsExperience;
                OldCoach.image = Coach.image;

                _identityApplicationContext.SaveChangesAsync();
            }
                

            
            return OldCoach;
            
        }
        public Coach GetCoachProfile(IdentityApplicationUser User)
        {
            var x = User;
            return User.Coach;
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
