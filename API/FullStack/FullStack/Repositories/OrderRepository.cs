using FullStack.Entities;
using FullStack.Data;
using FullStack.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> ObterPorStatusAsync(int[] status)
        {
            return await _context.Orders
                .Where(o => status.Any(s => s == o.CurrentStatus))
                .ToListAsync();
        }

        public async Task AdicionarAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
