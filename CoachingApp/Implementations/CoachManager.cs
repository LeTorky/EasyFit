using CoachingApp.DTO;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.EntityFrameworkCore;

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
        // get clients by id
        public async Task<Coach> GetCoachByID(int ID)
        {
            var coach = await _identityApplicationContext.Coaches.Where(i => i.id == ID).FirstOrDefaultAsync();
            return coach;
        }
        //return Nutration subs
        // both et all sub are active or still under approval 
        public async Task<IEnumerable<Client_NSub>> GetallCoachNsub(int id)
        {
            var Subs = await _identityApplicationContext.Client_NSubs.Where(s => s.coachID == id).ToListAsync();
            return Subs;

        }
        //return workout subs
        public async Task<IEnumerable<Client_WSub>> GetallCoachWsub(int id)
        {
            var Subs = await _identityApplicationContext.Client_WSubs.Where(s => s.coachID == id).ToListAsync();
            return Subs;

        }
    }
}
