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

namespace Bookshare.ApplicationServices.Queries.BookQueries
{
    public sealed class GetBookByIdQuery : IRequest<OperationResult<Book>>
    {
        public int Id { get; set; }
    }

    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator(IGenericRules<Book> rules)
        {
            RuleFor(_ => _.Id)
                .MustAsync((id, cancellationToken) => rules.AnyAsyncDbContext(x => x.Id == id, cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, nameof(Book), nameof(Book.Id), _.Id));
        }
    }

    public sealed class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, OperationResult<Book>>
    {
        private readonly BookshareDbContext _context;

        public GetBookByIdQueryHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.Where(x => x.Id == request.Id)
                .Include(x => x.Authors)
                .Include(x => x.Library)
                .FirstOrDefaultAsync(cancellationToken);

            return OperationResult.Ok(book);
        }
    }
}