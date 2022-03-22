using System;

namespace Bookshare.Domain.Contracts
{
    public interface IWithDateModified
    {
        DateTimeOffset? DateModified { get; }

        void SetDateModified(DateTimeOffset value);
    }
}
