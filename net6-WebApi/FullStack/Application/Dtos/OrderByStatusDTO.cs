namespace FullStack.Application.Dtos
{
    public class OrderByStatusDTO
    {
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string ProviderSuburb { get; set; }
        public string Category { get; set; }
        public int Id { get; set; }
        public string Details { get; set; }
        public decimal Value { get; set; }
        public int Status { get; set; }
        public string ProviderPhone{ get; set; }
        public string ProviderEmail { get; set; }
    }
}
