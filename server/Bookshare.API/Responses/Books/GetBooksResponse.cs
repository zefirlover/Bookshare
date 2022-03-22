using System.Collections.Generic;
using Bookshare.Domain.Models;

namespace Bookshare.API.Responses.Books
{
    public class GetBooksResponse
    {
        public List<Book>? Books { get; set; }
    }
}
