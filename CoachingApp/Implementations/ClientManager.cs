﻿using CoachingApp.DTO;
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
        public Client CreateClient(ClientUserDTO ClientUser, Guid UserId)
        {
            Client NewClient = new Client()
            {
                UserId = UserId,
                firstName = ClientUser.firstName,
                lastName = ClientUser.lastName,
                age = ClientUser.age,
                mobileNum = ClientUser.mobileNum,
                gender = ClientUser.gender,
                city = ClientUser.city,
                country = ClientUser.country,
            };
            _identityApplicationContext.Clients.Add(ClientUser);
            _identityApplicationContext.SaveChanges();
            return NewClient;
        }

        // get clients by id
        public async Task<Client> GetClientByID(int ID)
        {
            var Client = await _identityApplicationContext.Clients.Where(i => i.id == ID).FirstOrDefaultAsync();
            return Client;
        }

      
    }
}
