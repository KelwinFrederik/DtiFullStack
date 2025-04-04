using FullStack.Application.Dtos;
using FullStack.Application.Queries;
using FullStack.Data;
using FullStack.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Application.Handles
{
    public class GetOrdersByStatusHandler : IRequestHandler<GetOrdersByStatusQuery, List<OrderByStatusDTO>>
    {
        private readonly AppDbContext _dbContext;

        public GetOrdersByStatusHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderByStatusDTO>> Handle(GetOrdersByStatusQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders
                .Where(o => o.CurrentStatus == request.Status)
                .Include(o => o.Provider)
                .Select(o => new OrderByStatusDTO
                {
                    Id = o.Id,
                    Category = o.Category,
                    Value = o.TotalValue,
                    Status = o.CurrentStatus,
                    ProviderFirstName = o.Provider.FirstName ,
                    ProviderLastName = o.Provider.LastName,
                    ProviderSuburb = o.Provider.Suburb,
                    ProviderPhone = o.Provider.Phone,
                    ProviderEmail = o.Provider.Email,
                    Details = o.Details,
                    DateTimeCreated = o.DateTimeCreated
                })
                .ToListAsync();
        }
    }
}
