using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.Constants;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.Commands.BookCommands
{
    public sealed class AddBookCommand : IRequest<OperationResult>
    {
        public string? Name { get; set; }
        public int LibraryId { get; set; }
        public List<int>? AuthorIds { get; set; }
    }

    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator(IGenericRules<Library> rules)
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage(string.Format(ErrorConstants.FieldIsRequired, nameof(AddBookCommand.Name)));

            RuleFor(_ => _.LibraryId)
                .MustAsync((id, cancellationToken) => rules.AnyAsyncDbContext(x => x.Id == id, cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, nameof(Library), nameof(Library.Id), _.LibraryId));
        }
    }

    public sealed class AddBookCommandHandler : IRequestHandler<AddBookCommand, OperationResult>
    {
        private readonly BookshareDbContext _context;

        public AddBookCommandHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var authorIds = request.AuthorIds ?? new List<int>();

            var library = await _context.Libraries.FindAsync(request.LibraryId);

            var authors = await _context.Authors.Where(x => authorIds.Contains(x.Id)).ToListAsync(cancellationToken);

            var book = new Book
            {
                Name = request.Name,
                Library = library,
                Authors = authors,
                PhotoPath = null,
            };

            await _context.Books.AddAsync(book, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return OperationResult.Ok();
        }
    }
}
