using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.General;
using Bookshare.Domain.Models;
using Bookshare.DomainServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.Queries.LibraryQueries
{
    public sealed class GetLibrariesQuery : IRequest<OperationResult<List<Library>>>
    {
    }

    public sealed class GetLibrariesQueryHandler : IRequestHandler<GetLibrariesQuery, OperationResult<List<Library>>>
    {
        private readonly BookshareDbContext _context;

        public GetLibrariesQueryHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<List<Library>>> Handle(GetLibrariesQuery request, CancellationToken cancellationToken)
        {
            var libraries = await _context.Libraries
                .Include(x => x.Books)
                .ThenInclude(x => x.Authors)
                .ToListAsync(cancellationToken);

            return OperationResult.Ok(libraries);
        }
    }
}