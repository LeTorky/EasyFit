using CoachingApp.DTO;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class ClientManager:IClientManager
    {
        private IdentityApplicationContext _identityApplicationContext;
        public ClientManager(IdentityApplicationContext identityApplicationContext)
        {
            _identityApplicationContext = identityApplicationContext;
        }
        public Client CreateClient(ClientUserDTO CoachUser, Guid UserId)
        {
            Client NewClient = new Client()
            {
                UserId = UserId,
                firstName = CoachUser.firstName,
                lastName = CoachUser.lastName,
                age = CoachUser.age,
                mobileNum = CoachUser.mobileNum,
                gender = CoachUser.gender,
                city = CoachUser.city,
                country = CoachUser.country,
            };
            _identityApplicationContext.Clients.Add(NewClient);
            _identityApplicationContext.SaveChanges();
            return NewClient;
        }

        // get clients by id
        public async Task<Client> GetClientByID(int ID)
        {
            var Client = await _identityApplicationContext.Clients.Where(i => i.id == ID).FirstOrDefaultAsync();
            return Client;
        }

        //return Nutration subs
        // both et all sub are active or still under approval 
        public async Task<IEnumerable<Client_NSub>> GetallClientNsub(int id)
        {
            var Subs = await _identityApplicationContext.Client_NSubs.Where(s => s.clientID == id).ToListAsync();
            return Subs;

        }
        //return workout subs
        public async Task<IEnumerable<Client_WSub>> GetallClientWsub(int id)
        {
            var Subs = await _identityApplicationContext.Client_WSubs.Where(s => s.clientID == id).ToListAsync();
            return Subs;

        }
    }
}
