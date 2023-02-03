using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Test.Models;
using WebApi_Test.Repository.Interfaces;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetAllOrders()
        {
            List<OrderModel> orders = await _orderRepository.ListAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> OrderById(int id)
        {
            OrderModel order = await _orderRepository.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderModel>> AddOrder([FromBody] OrderModel orderModel)
        {
            OrderModel newOrder = await _orderRepository.AddOrder(orderModel);
            return Ok(newOrder);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderModel>> UpdateOrderInfos([FromBody] OrderModel orderModel, int id)
        {
            orderModel.Id = id;
            OrderModel order = await _orderRepository.UpdateOrder(orderModel, id);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> DeleteOrder(int id)
        {
            bool deleted = await _orderRepository.DeleteOrder(id);
            return Ok(deleted);
        }
    }
}
