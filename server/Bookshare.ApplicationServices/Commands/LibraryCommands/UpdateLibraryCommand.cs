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
    public class UpdateLibraryCommand : IRequest<OperationResult<Library>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateLibraryCommandValidator : AbstractValidator<UpdateLibraryCommand>
    {
        public UpdateLibraryCommandValidator(IGenericRules<Library> rules)
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(UpdateLibraryCommand.Name)));

            RuleFor(_ => _.Id)
                .MustAsync((id, cancellationToken) => rules.AnyAsyncDbContext(x => x.Id == id, cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, nameof(Library), nameof(Library.Id), _.Id));

            RuleFor(_ => new { _.Id, _.Name })
                .MustAsync((library, cancellationToken) => rules.NotAnyAsyncDbContext(x => x.Id != library.Id && x.Name.ToLower() == library.Name.ToLower(), cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityAlreadyExists, nameof(Library), nameof(Library.Name), _.Name));
        }
    }

    public sealed class UpdateLibraryCommandHandler : IRequestHandler<UpdateLibraryCommand, OperationResult<Library>>
    {
        private readonly BookshareDbContext _context;

        public UpdateLibraryCommandHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<Library>> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
        {
            var library = await _context.Libraries.FindAsync(request.Id);

            library.Name = request.Name;

            _context.Libraries.Update(library);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok(library);
        }
    }
}