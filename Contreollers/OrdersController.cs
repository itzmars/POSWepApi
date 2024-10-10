using Microsoft.AspNetCore.Mvc;
using POSWebApi.Models;
using POSWebApi.Repositories.IRepositories;

namespace POSWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderRepository _orderRepo;

        public OrdersController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        //Get: /orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            return Ok(orders);
        }

        //Get: /orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            return Ok(order);
        }

        //Post: /orders
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Order order)
        {
            await _orderRepo.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(Guid id, [FromBody] Order order){
             var existingOrder = await _orderRepo.GetOrderByIdAsync(id);
            if (existingOrder == null) { 
                return NotFound();
            }

            order.Id = id;
            await _orderRepo.UpdateOrderAsync(order);
            return NoContent();

        }

        //Delete /orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrde (Guid id){
            var existingOrder = await _orderRepo.GetOrderByIdAsync(id);
            if (existingOrder == null) { 
                return NotFound();
            }
            await _orderRepo.DeleteOrderAsync(id);
            return NoContent();
        }

    }
}