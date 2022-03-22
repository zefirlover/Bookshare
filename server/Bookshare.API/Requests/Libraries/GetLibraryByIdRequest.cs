using Microsoft.AspNetCore.Mvc;

namespace Bookshare.API.Requests.Libraries
{
    public class GetLibraryByIdRequest
    {
        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
    }
}
