using Microsoft.EntityFrameworkCore;
using POSWebApi.Data;
using POSWebApi.Models;
using POSWebApi.Repositories.IRepositories;

namespace POSWebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly POSDbContext _context;

        public OrderRepository(POSDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Oders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _context.Oders
                .Include(o =>o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync();
        }


        public async Task CreateOrderAsync(Order order)
        {
            if (order.Id == Guid.Empty)
            {
                order.Id = Guid.NewGuid();
            }

            order.TotalAmount = order.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity);
            _context.Oders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var existingOrder = await _context.Oders.FindAsync(order.Id);
            if(existingOrder == null){
                throw new KeyNotFoundException();
            }
            existingOrder.CustomerId = order.CustomerId;
            existingOrder.OrderItems = order.OrderItems;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity);
            
            _context.Oders.Update(existingOrder);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteOrderAsync(Guid id)
        {
            var existingOrder = await _context.Oders.FindAsync(id);

            if (existingOrder == null)
            {
                throw new KeyNotFoundException($"id:{id} not found");
            }

            _context.Oders.Remove(existingOrder);
            await _context.SaveChangesAsync();
        }
    }
}