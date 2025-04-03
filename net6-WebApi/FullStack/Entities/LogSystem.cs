namespace FullStack.Entities
{
    public class LogSystem
    {
        public Guid Id { get; set; }
        public DateTime DateTimeCreated { get; set; } = DateTime.UtcNow;
        public int ImportanceLevel { get; set; }
        public string EventMessage { get; set; } = string.Empty;
        public string? Details { get; set; }
    }
}
