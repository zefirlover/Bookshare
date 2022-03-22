using System.Collections.Generic;
using Bookshare.Domain.Models;

namespace Bookshare.API.Responses.Libraries
{
    public class GetLibrariesResponse
    {
        public List<Library>? Libraries { get; set; }
    }
}
