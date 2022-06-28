namespace Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        void SendEmail(IEnumerable<string> to, string subject, string content);
        Task SendEmailAsync(IEnumerable<string> to, string subject, string content);
    }
}