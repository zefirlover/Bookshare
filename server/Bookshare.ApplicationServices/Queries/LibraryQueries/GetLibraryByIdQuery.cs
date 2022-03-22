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

namespace Bookshare.ApplicationServices.Queries.LibraryQueries
{
    public sealed class GetLibraryByIdQuery : IRequest<OperationResult<Library>>
    {
        public int Id { get; set; }
    }

    public class GetLibraryByIdQueryValidator : AbstractValidator<GetLibraryByIdQuery>
    {
        public GetLibraryByIdQueryValidator(IGenericRules<Library> rules)
        {
            RuleFor(_ => _.Id)
                .MustAsync((id, cancellationToken) => rules.AnyAsyncDbContext(x => x.Id == id, cancellationToken))
                .WithMessage(_ => string.Format(ErrorConstants.EntityNotFound, nameof(Library), nameof(Library.Id), _.Id));
        }
    }

    public sealed class GetLibraryByIdQueryHandler : IRequestHandler<GetLibraryByIdQuery, OperationResult<Library>>
    {
        private readonly BookshareDbContext _context;

        public GetLibraryByIdQueryHandler(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<Library>> Handle(GetLibraryByIdQuery request, CancellationToken cancellationToken)
        {
            var library = await _context.Libraries
                .Where(x => x.Id == request.Id)
                .Include(x => x.Books)
                .ThenInclude(x => x.Authors)
                .FirstOrDefaultAsync(cancellationToken);

            return OperationResult.Ok(library);
        }
    }
}