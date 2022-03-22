using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.DomainServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.Queries.BookQueries
{
    public sealed class GetBooksQuery : IRequest<OperationResult<List<Book>>>
    {
    }

    public sealed class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, OperationResult<List<Book>>>
    {
        private readonly BookshareDbContext _context;

        public GetBooksQueryHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<List<Book>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _context.Books
                .Include(x => x.Authors)
                .Include(x => x.Library)
                .ToListAsync(cancellationToken);

            return OperationResult.Ok(books);
        }
    }
}