using CoachingApp.DTO;
using CoachingApp.Interfaces;
using CoachingApp.Models;

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
    }
}
