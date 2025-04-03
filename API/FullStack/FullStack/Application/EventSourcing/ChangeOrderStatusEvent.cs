namespace FullStack.Application.EventSourcing
{
    public class ChangeOrderStatusEvent
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }

        public ChangeOrderStatusEvent(Guid ordemId, string status)
        {
            OrderId = ordemId;
            Status = status;
        }
    }
}
