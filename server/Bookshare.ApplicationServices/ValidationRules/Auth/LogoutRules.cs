using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.ValidationRules.Auth
{
    public interface ILogoutRules : IValidationRule
    {
        Task<bool> UserIsRegistered(string userName, CancellationToken cancellationToken);
    }

    public sealed class LogoutRules : ILogoutRules
    {
        private readonly BookshareDbContext _context;

        public LogoutRules(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserIsRegistered(string userName, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(_ => _.UserName.ToLower().Equals(userName.ToLower()), cancellationToken);
        }
    }
}
