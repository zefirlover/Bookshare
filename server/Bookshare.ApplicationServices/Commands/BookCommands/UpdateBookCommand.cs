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
    public class UpdateBookCommand : IRequest<OperationResult<Book>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator(IGenericRules<Book> rules)
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(AddBookCommand.Name)));

            RuleFor(_ => _.Id)
                .MustAsync((id, cancellationToken) => rules.AnyAsyncDbContext(x => x.Id == id, cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, nameof(Book), nameof(Book.Id), _.Id));
        }
    }

    public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, OperationResult<Book>>
    {
        private readonly BookshareDbContext _context;

        public UpdateBookCommandHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            book.Name = request.Name;

            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok(book);
        }
    }
}