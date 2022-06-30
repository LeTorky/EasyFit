using CoachingApp.DTO;
using CoachingApp.Models;

namespace CoachingApp.Interfaces
{
    public interface IClientManager
    {
        public Client CreateClient(ClientUserDTO CoachUser, Guid UserId);
        public  Task<Client> GetClientByID(int ID);

    }
}
