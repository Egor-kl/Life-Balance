using System.Threading.Tasks;

namespace Life_Balance.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
