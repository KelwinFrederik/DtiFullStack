using MediatR;

namespace FullStack.Application.Commands
{
    public class ChangeOrderStatusCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public int NewStatus { get; set; }
    }
}
