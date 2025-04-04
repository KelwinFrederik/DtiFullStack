using FullStack.Entities;
using FullStack.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Text;

public class EmailService : IEmailService
{
    private readonly string _folderPath;

    public EmailService()
    {        
        _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "EmailsSimulados");
        if (!Directory.Exists(_folderPath))
            Directory.CreateDirectory(_folderPath);
    }

    public async Task SendEmailAsync(string to, string subject, Order order)
    {
        var fileName = $"Email_Order_{subject}.txt";
        var filePath = Path.Combine(_folderPath, fileName);

        var emailContent = new StringBuilder();
        emailContent.AppendLine($"To: {to}");
        emailContent.AppendLine("From: no-reply@fullstackapp.com");
        emailContent.AppendLine("Subject: 🚀 Sua ordem foi aceita!");
        emailContent.AppendLine("--------------------------------------------------");
        emailContent.AppendLine($"Olá {order.Provider.FirstName},");
        emailContent.AppendLine($"Sua ordem #{order.Id} foi **ACEITA** com sucesso.");
        emailContent.AppendLine($"📅 Data Criação: {order.DateTimeCreated}");
        emailContent.AppendLine($"📍 Bairro: {order.Provider.Suburb}");
        emailContent.AppendLine($"📦 Categoria: {order.Category}");
        emailContent.AppendLine($"💰 Valor: R$ {order.TotalValue:C}");
        emailContent.AppendLine($"✉️ Descrição: {order.Details}");
        emailContent.AppendLine("--------------------------------------------------");
        emailContent.AppendLine("Atenciosamente,");
        emailContent.AppendLine("🚀 FullStackApp Team");
        
        await File.WriteAllTextAsync(filePath, emailContent.ToString(), Encoding.UTF8);
    }
}
