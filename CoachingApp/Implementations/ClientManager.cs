using CoachingApp.DTO;
using CoachingApp.Interfaces;
using CoachingApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoachingApp.Implementations
{
    public class ClientManager : IClientManager
    {
        private IdentityApplicationContext _identityApplicationContext;
        // private readonly UserManager<Client> _userManager;
        // private readonly SignInManager<Client> _signInManager;
        public ClientManager(IdentityApplicationContext identityApplicationContext/*/, UserManager<Client> userManager, SignInManager<Client> signInManager/*/)
        {

            _identityApplicationContext = identityApplicationContext;
            // _userManager = userManager;
            //_signInManager = signInManager;



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

        public Client GetClientById(int id)
        {
            var Client = _identityApplicationContext.Clients.Where(c => c.id == id).SingleOrDefault();

            return Client;
        }



        public List<Client> GetAllClients()
        {
            var Clients = _identityApplicationContext.Clients.ToList();

            return Clients;
        }



        public async Task DeleteClient(int id)
        {
            var Clients = await _identityApplicationContext.Clients.FindAsync(id);
            _identityApplicationContext.Clients.Remove(Clients);
            await _identityApplicationContext.SaveChangesAsync();

        }
        public async Task UpdateClient(int id, ClientUserDTO obj)
        {
            int x = id;
            var Clients =  _identityApplicationContext.Clients.Where(i=>i.id==id).FirstOrDefault();
            Clients.firstName = obj.firstName;
            Clients.lastName = obj.lastName;
            Clients.age = obj.age;
            Clients.mobileNum = obj.mobileNum;
         //   Clients.gender = obj.gender;
            Clients.city = obj.city;
            Clients.country = obj.country;
            Clients.weight = obj.weight;
            Clients.height = obj.height;
            await _identityApplicationContext.SaveChangesAsync();
        }
        //bring the user who sign in
        public async Task<Client> GetClientProfile(int id)
        {
            

            var Clients = await _identityApplicationContext.Clients.FindAsync(id);
            return Clients;

        }

        public List<Client> GetAllByWorkOut()
        {
            var clientWithWork = _identityApplicationContext.Clients.Include(a => a.Client_Workout_WSubs).ToList();
            return clientWithWork;
        }
    }
}