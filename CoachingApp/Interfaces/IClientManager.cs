using CoachingApp.DTO;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IClientManager
    { 

        public Client CreateClient(ClientUserDTO CoachUser, Guid UserId);
             Client GetClientById(int id);
     
            List<Client> GetAllClients();

            Task DeleteClient(int id);
       
             Task UpdateClient(int id, ClientUserDTO obj);
        
              Task<Client> GetClientProfile(int userId);

             List<Client> GetAllByWorkOut();
    }
}
