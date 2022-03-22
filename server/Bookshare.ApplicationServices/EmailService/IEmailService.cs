using System.Threading.Tasks;
using Bookshare.ApplicationServices.EmailService.Models;

namespace Bookshare.ApplicationServices.EmailService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(Email email, EmailContact contact);
    }
}
