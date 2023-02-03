using WebApi_Test.Models;

namespace WebApi_Test.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModel>> ListAllOrders();
        Task<OrderModel> GetOrderById(int id);
        Task<OrderModel> AddOrder(OrderModel client);
        Task<OrderModel> UpdateOrder(OrderModel client, int id);
        Task<bool> DeleteOrder(int id);
    }
}
