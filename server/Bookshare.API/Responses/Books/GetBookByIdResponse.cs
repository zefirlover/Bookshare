using System;
using System.Collections.Generic;
using Bookshare.Domain.Models;

namespace Bookshare.API.Responses.Books
{
    public class GetBookByIdResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Author>? Authors { get; set; }
        public Library? Library { get; set; }
        public string? PhotoPath { get; set; }
        public DateTimeOffset DateCreated { get; private set; }
        public DateTimeOffset? DateModified { get; private set; }
    }
}
