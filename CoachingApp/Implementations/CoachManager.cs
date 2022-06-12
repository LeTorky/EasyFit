using CoachingApp.Controllers;
using CoachingApp.Identity;
using CoachingApp.Interfaces;
using CoachingApp.Models;

namespace CoachingApp.Implementations
{
    public class CoachManager:ICoachManager
    {
        private IdentityApplicationContext context { get; set; }
        public CoachManager(IdentityApplicationContext _context)
        {
            this.context = _context;
        }

        public object GetCoachById(int id)
        {
            //var GetCoach = context.Coaches.Where(c => c.id == id).Select(s => new Coach{id= s.id,age= s.age,Certificates= s.Certificates,email= s.email,Workout_Subscriptions= s.Workout_Subscriptions});
            var GetCoach = context.Coaches.Where(c => c.id == id).Select(s => new { s.id ,s.firstName,s.lastName , s.age, s.Certificates, s.email });

            return GetCoach;
        }

        public List<Coach> GetAllCoaches()
        {
            var GetCoachs = context.Coaches.ToList();
            return GetCoachs;
        }

        public Coach DeleteCoach(int id)
        {
            var CoachData = context.Coaches.Where(e => e.id == id).SingleOrDefault();
            if (CoachData != null)
                context.Coaches.Remove(CoachData);

            context.SaveChanges();
            return CoachData;
        }
        public Coach UpdateCoach(int id,Coach Coach)
        {
            Coach OldCoach = context.Coaches.Where(c => c.id == id).SingleOrDefault();

            if (OldCoach != null)
            {
                OldCoach.mobileNum = Coach.mobileNum;
                OldCoach.city = Coach.city;
                OldCoach.country = Coach.country;
                OldCoach.email = Coach.email;
                OldCoach.age = Coach.age;
                OldCoach.firstName = Coach.firstName;
                OldCoach.lastName = Coach.lastName;
                OldCoach.gender = Coach.gender;
                OldCoach.yearsExperience = Coach.yearsExperience;
                OldCoach.image = Coach.image;

                context.SaveChangesAsync();
            }
                

            
            return OldCoach;
            
        }
        public Coach GetCoachProfile(IdentityApplicationUser User)
        {
            return User.Coach;
        }
    }
}
