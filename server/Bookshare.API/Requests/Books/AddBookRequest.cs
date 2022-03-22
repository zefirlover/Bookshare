using System.Collections.Generic;

namespace Bookshare.API.Requests.Books
{
    public class AddBookRequest
    {
        public string? Name { get; set; }
        public int LibraryId { get; set; }
        public List<int>? AuthorIds { get; set; }
    }
}
