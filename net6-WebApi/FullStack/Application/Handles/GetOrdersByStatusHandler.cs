using FullStack.Application.Queries;
using FullStack.Data;
using FullStack.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Application.Handles
{
    public class GetOrdersByStatusHandler : IRequestHandler<GetOrdersByStatusQuery, List<Order>>
    {
        private readonly AppDbContext _dbContext;

        public GetOrdersByStatusHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> Handle(GetOrdersByStatusQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders
                .Where(o => o.CurrentStatus == request.Status)
                .ToListAsync();
        }
    }
}
