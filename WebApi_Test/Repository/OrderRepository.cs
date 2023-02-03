using Microsoft.EntityFrameworkCore;
using WebApi_Test.Data;
using WebApi_Test.Models;
using WebApi_Test.Repository.Interfaces;

namespace WebApi_Test.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectsDBContext _dbContext;

        public OrderRepository(ProjectsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderModel> GetOrderById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<OrderModel>> ListAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrderModel> AddOrder(OrderModel order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<OrderModel> UpdateOrder(OrderModel order, int id)
        {
            OrderModel orderById = await GetOrderById(id);

            if (orderById == null)
            {
                throw new Exception($"Order {id} not found!");
            }

            orderById.OrderNumber = order.OrderNumber;
            orderById.ItemId = order.ItemId;
            orderById.ClientId = order.ClientId;

            _dbContext.Orders.Update(orderById);
            await _dbContext.SaveChangesAsync();

            return orderById;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            OrderModel orderById = await GetOrderById(id);

            if (orderById == null)
            {
                throw new Exception($"Order {id} not found!");
            }

            _dbContext.Orders.Remove(orderById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
