using FullStack.Entities;

namespace FullStack.Interfaces
{    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, Order order);
    }
}
