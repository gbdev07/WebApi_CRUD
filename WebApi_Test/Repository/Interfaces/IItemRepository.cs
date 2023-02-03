using WebApi_Test.Models;

namespace WebApi_Test.Repository.Interfaces
{
    public interface IItemRepository
    {
        Task<List<ItemModel>> ListAllItems();
        Task<ItemModel> GetItemById(int id);
        Task<ItemModel> AddItem(ItemModel client);
        Task<ItemModel> UpdateItem(ItemModel client, int id);
        Task<bool> DeleteItem(int id);
    }
}
