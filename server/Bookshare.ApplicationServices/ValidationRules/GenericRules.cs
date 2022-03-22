using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.ValidationRules;
using Bookshare.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.ApplicationServices.ValidationRules
{
    public class GenericRules<T> : IGenericRules<T>
        where T : class
    {
        private readonly BookshareDbContext _context;

        public GenericRules(BookshareDbContext context)
        {
            _context = context;
        }

        public async Task<bool> NotAnyAsyncDbContext(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return !await _context.Set<T>().AnyAsync(predicate, cancellationToken);
        }

        public async Task<bool> AnyAsyncDbContext(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AnyAsync(predicate, cancellationToken);
        }
    }
}
