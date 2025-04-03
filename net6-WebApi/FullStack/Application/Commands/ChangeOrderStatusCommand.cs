using MediatR;

namespace FullStack.Application.Commands
{
    public class ChangeOrderStatusCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
        public StatusOrderEnum NovoStatus { get; set; }
    }
}
