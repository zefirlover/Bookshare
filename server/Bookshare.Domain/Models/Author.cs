using System.Collections.Generic;

namespace Bookshare.Domain.Models
{
    public sealed class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
