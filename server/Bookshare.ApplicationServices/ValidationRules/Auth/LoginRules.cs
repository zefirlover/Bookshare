using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.ValidationRules.Auth
{
    public interface ILoginRules : IValidationRule
    {
        Task<bool> UserIsRegistered(string userName, CancellationToken cancellationToken);
    }

    public sealed class LoginRules : ILoginRules
    {
        private readonly BookshareDbContext _context;

        public LoginRules(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserIsRegistered(string userName, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(_ => _.UserName.ToLower().Equals(userName.ToLower()), cancellationToken);
        }
    }
}
