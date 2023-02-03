using Microsoft.EntityFrameworkCore;
using WebApi_Test.Data;
using WebApi_Test.Models;
using WebApi_Test.Repository.Interfaces;

namespace WebApi_Test.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ProjectsDBContext _dbContext;
        public ItemRepository(ProjectsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ItemModel> GetItemById(int id)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ItemModel>> ListAllItems()
        {
            return await _dbContext.Items.ToListAsync();
        }

        public async Task<ItemModel> AddItem(ItemModel item)
        {
            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item;
        }

        public async Task<ItemModel> UpdateItem(ItemModel item, int id)
        {
            ItemModel itemById = await GetItemById(id);

            if(itemById == null)
            {
                throw new Exception($"Item {id} not found!");
            }

            itemById.Name = item.Name;
            itemById.Value = item.Value;
            itemById.OrderId = item.OrderId;

            _dbContext.Items.Update(itemById);
            await _dbContext.SaveChangesAsync();

            return itemById;
        }

        public async Task<bool> DeleteItem(int id)
        {
            ItemModel itemById = await GetItemById(id);

            if (itemById == null)
            {
                throw new Exception($"Item {id} not found!");
            }

            _dbContext.Items.Remove(itemById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
