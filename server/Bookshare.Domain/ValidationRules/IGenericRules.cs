using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshare.Domain.ValidationRules
{
    public interface IGenericRules<T> : IValidationRule where T : class
    {
        Task<bool> NotAnyAsyncDbContext(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<bool> AnyAsyncDbContext(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
