using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using FluentValidation;
using MediatR;

namespace Bookshare.ApplicationServices.Commands.BookCommands
{
    public sealed class RemoveBookByIdCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
    }

    public class RemoveBookByIdCommandValidator : AbstractValidator<RemoveBookByIdCommand>
    {
        public RemoveBookByIdCommandValidator(IGenericRules<Book> rules)
        {
            RuleFor(_ => _.Id)
                .MustAsync((id, cancellationToken) => rules.AnyAsyncDbContext(x => x.Id == id, cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, nameof(Book), nameof(Book.Id), _.Id));
        }
    }

    public sealed class RemoveBookByIdCommandHandler : IRequestHandler<RemoveBookByIdCommand, OperationResult>
    {
        private readonly BookshareDbContext _context;

        public RemoveBookByIdCommandHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(RemoveBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok();
        }
    }
}