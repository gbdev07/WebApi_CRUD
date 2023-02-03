using WebApi_Test.Models;

namespace WebApi_Test.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientModel>> ListAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<ClientModel> AddClient(ClientModel client);
        Task<ClientModel> UpdateClient(ClientModel client, int id);
        Task<bool> DeleteClient(int id);
    }
}
