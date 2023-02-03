using Microsoft.EntityFrameworkCore;
using WebApi_Test.Data;
using WebApi_Test.Models;
using WebApi_Test.Repository.Interfaces;

namespace WebApi_Test.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ProjectsDBContext _dbContext;
        public ClientRepository(ProjectsDBContext projectsDBContext)
        {
            _dbContext= projectsDBContext;
        }
        
        public async Task<ClientModel> GetClientById(int id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ClientModel>> ListAllClients()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<ClientModel> AddClient(ClientModel client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();

            return client;
        }

        public async Task<ClientModel> UpdateClient(ClientModel client, int id)
        {
            ClientModel clientById = await GetClientById(id);

            if(clientById == null)
            {
                throw new Exception($"Client {id} not found!");
            }

            clientById.Name = client.Name;
            clientById.Email = client.Email;

            _dbContext.Clients.Update(clientById);
            await _dbContext.SaveChangesAsync();

            return clientById;
        }

        public async Task<bool> DeleteClient(int id)
        {
            ClientModel clientById = await GetClientById(id);

            if (clientById == null)
            {
                throw new Exception($"Client {id} not found!");
            }

            _dbContext.Clients.Remove(clientById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
