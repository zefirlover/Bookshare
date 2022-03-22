using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using FluentValidation;
using MediatR;

namespace Bookshare.ApplicationServices.Commands.LibraryCommands
{
    public sealed class AddLibraryCommand : IRequest<OperationResult>
    {
        public string? Name { get; set; }
    }

    public class AddLibraryCommandValidator : AbstractValidator<AddLibraryCommand>
    {
        public AddLibraryCommandValidator(IGenericRules<Library> rules)
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(AddLibraryCommand.Name)))
                .MustAsync((name, cancellationToken) => rules.NotAnyAsyncDbContext(x => x.Name.ToLower() == name.ToLower(), cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityAlreadyExists, nameof(Library), nameof(Library.Name), _.Name));
        }
    }

    public sealed class AddLibraryCommandHandler : IRequestHandler<AddLibraryCommand, OperationResult>
    {
        private readonly BookshareDbContext _context;

        public AddLibraryCommandHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(AddLibraryCommand request, CancellationToken cancellationToken)
        {
            await _context.Libraries.AddAsync(new Library { Name = request.Name }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok();
        }
    }
}
