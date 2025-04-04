namespace FullStack.Application.EventSourcing
{
    public class ChangeOrderStatusEvent
    {
        public int OrderId { get; set; }
        public string Status { get; set; }

        public ChangeOrderStatusEvent(int ordemId, string status)
        {
            OrderId = ordemId;
            Status = status;
        }
    }
}
