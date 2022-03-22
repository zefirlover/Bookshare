using System;
using System.Collections.Generic;
using Bookshare.Domain.Contracts;

namespace Bookshare.Domain.Models
{
    public sealed class Book : IWithDateCreated, IWithDateModified
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Author> Authors { get; set; } = new();
        public Library? Library { get; set; }
        public string? PhotoPath { get; set; }
        public DateTimeOffset DateCreated { get; private set; }
        public DateTimeOffset? DateModified { get; private set; }
        void IWithDateCreated.SetDateCreated(DateTimeOffset value) => DateCreated = value;
        void IWithDateModified.SetDateModified(DateTimeOffset value) => DateModified = value;
    }
}
