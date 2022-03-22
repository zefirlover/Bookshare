using System.Collections.Generic;
using Bookshare.Domain.Models;

namespace Bookshare.API.Responses.Libraries
{
    public class GetLibraryByIdResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
