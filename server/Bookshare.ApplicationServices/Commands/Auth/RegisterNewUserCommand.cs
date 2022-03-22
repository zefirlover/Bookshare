﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookshare.ApplicationServices.ValidationRules.Auth;
using Bookshare.Domain.Constants;
using Bookshare.Domain.Enums;
using Bookshare.Domain.General;
using Bookshare.DomainServices;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bookshare.ApplicationServices.Commands.Auth
{
    public sealed class RegisterNewUserCommand : IRequest<OperationResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterNewUserCommandValidator : AbstractValidator<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidator(IRegisterNewUserValidationRules rules)
        {
            RuleFor(_ => _.Email)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(RegisterNewUserCommand.Email)))
                .MustAsync(rules.UserNameIsUnique)
                .WithMessage(_ => string.Format(ErrorConstants.EntityAlreadyExists, "User", nameof(RegisterNewUserCommand.Email), _.Email));

            RuleFor(_ => _.Password)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(RegisterNewUserCommand.Password)));

            RuleFor(_ => _.ConfirmPassword)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, "Confirm Password"))
                .Must((registerNewUserCommand, confirmPassword) => registerNewUserCommand.Password.Trim().Equals(confirmPassword.Trim()))
                .WithMessage(ErrorConstants.PasswordsDoNotMatch);
        }
    }

    public sealed class RegisterNewUserCommandHandler : IRequestHandler<RegisterNewUserCommand, OperationResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterNewUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<OperationResult> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            var userRegisteredResult = await _userManager.CreateAsync(newUser, request.Password);

            if (!userRegisteredResult.Succeeded)
            {
                return OperationResult.Fail(userRegisteredResult.Errors.Select(_ => _.Description).ToList());
            }

            var userObtainedRoleStudentResult = await _userManager.AddToRoleAsync(newUser, DomainRoles.Student.ToString());

            if (!userObtainedRoleStudentResult.Succeeded)
            {
                return OperationResult.Fail(userObtainedRoleStudentResult.Errors.Select(_ => _.Description).ToList());
            }

            return OperationResult.Ok();
        }
    }
}
