using FullStack.Application.Commands;
using FullStack.Application.EventSourcing;
using FullStack.Data;
using FullStack.Interfaces;
using MediatR;

namespace FullStack.Application.Handles
{
    public class ChangeOrderStatusHandler : IRequestHandler<ChangeOrderStatusCommand, bool>
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventStore _eventStore;

        public ChangeOrderStatusHandler(AppDbContext dbContext, IEventStore eventStore)
        {
            _dbContext = dbContext;
            _eventStore = eventStore;
        }

        public async Task<bool> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var ordem = await _dbContext.Orders.FindAsync(request.OrderId);
            if (ordem == null) return false;
            if(ordem.CurrentStatus == request.NewStatus) return true;

            if (request.NewStatus == (int)StatusOrderEnum.APROVADO && ordem.TotalValue > 500)
                ordem.TotalValue *= 0.9m;
            
            ordem.CurrentStatus = (int)request.NewStatus;
            await _dbContext.SaveChangesAsync();

            var orderAcceptedEvent = new ChangeOrderStatusEvent(request.OrderId,request.NewStatus.ToString());
            await _eventStore.Save(orderAcceptedEvent,(int)LogLevel.Information);

            return true;
        }
    }
}
