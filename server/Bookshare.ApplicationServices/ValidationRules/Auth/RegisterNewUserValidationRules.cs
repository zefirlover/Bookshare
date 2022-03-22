using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.ValidationRules.Auth
{
    public interface IRegisterNewUserValidationRules : IValidationRule
    {
        Task<bool> UserNameIsUnique(string userName, CancellationToken cancellationToken);
    }

    public sealed class RegisterNewUserValidationRules : IRegisterNewUserValidationRules
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterNewUserValidationRules(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> UserNameIsUnique(string userName, CancellationToken cancellationToken)
        {
            return !await _userManager.Users.AnyAsync(_ => _.NormalizedUserName.Equals(userName.ToUpper()), cancellationToken);
        }
    }
}
