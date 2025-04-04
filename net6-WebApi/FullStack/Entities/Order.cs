namespace FullStack.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int IdProvider { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;
        public string Category { get; set; } = string.Empty;
        public decimal TotalValue { get; set; }
        public string Details { get; set; } = string.Empty;
        public int CurrentStatus { get; set; }

        public Provider Provider { get; set; } = new Provider();
    }
}
