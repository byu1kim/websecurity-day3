using Day3.Models;
using SendGrid;
using System.Threading.Tasks;

namespace Day3.Data.Services
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(ComposeEmailModel payload);
    }
}
