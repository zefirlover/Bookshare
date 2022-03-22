using System.Threading;
using System.Threading.Tasks;
using Bookshare.ApplicationServices.JwtAuthService;
using Bookshare.ApplicationServices.ValidationRules.Auth;
using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.DomainServices;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bookshare.ApplicationServices.Commands.Auth
{
    public sealed class LogoutCommand : IRequest<OperationResult>
    {
        public string UserName { get; set; }
    }

    public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
    {
        public LogoutCommandValidator(ILogoutRules rules)
        {
            RuleFor(_ => _.UserName)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(ApplicationUser.UserName)))
                .MustAsync(rules.UserIsRegistered)
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, "User", nameof(ApplicationUser.Email), _.UserName));
        }
    }

    public sealed class LogoutCommandHandler : IRequestHandler<LogoutCommand, OperationResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public LogoutCommandHandler(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<OperationResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            _jwtService.RemoveRefreshTokenByUserName(user.UserName);

            return OperationResult.Ok();
        }
    }
}
