using FullStack.Application.Commands;
using FullStack.Application.EventSourcing;
using FullStack.Data;
using FullStack.Entities;
using FullStack.Interfaces;
using MediatR;

namespace FullStack.Application.Handles
{
    public class ChangeOrderStatusHandler : IRequestHandler<ChangeOrderStatusCommand, bool>
    {
        private readonly AppDbContext _dbContext;
        private readonly IEventStore _eventStore;
        private readonly IEmailService _emailService;

        public ChangeOrderStatusHandler(AppDbContext dbContext, IEventStore eventStore, IEmailService emailService)
        {
            _dbContext = dbContext;
            _eventStore = eventStore;
            _emailService = emailService;
        }

        public async Task<bool> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FindAsync(request.OrderId);
            if (order == null) return false;
            if(order.CurrentStatus == request.NewStatus) return true;

            order.CurrentStatus = (int)request.NewStatus;
            if (request.NewStatus == (int)StatusOrderEnum.APROVADO)
            {
                if(order.TotalValue > 500)
                    order.TotalValue *= 0.9m;

                await _emailService.SendEmailAsync(order.Provider.Email, "Pedido Aceito", order);
            }

            await _dbContext.SaveChangesAsync();
            
            var statusString = Enum.GetName(typeof(StatusOrderEnum), request.NewStatus)??"-";
            var orderAcceptedEvent = new ChangeOrderStatusEvent(request.OrderId, statusString);
            await _eventStore.Save(orderAcceptedEvent,(int)LogLevel.Information);

            return true;
        }
    }
}
