using Microsoft.AspNetCore.Mvc;

namespace Bookshare.API.Requests.Books
{
    public class GetBookByIdRequest
    {
        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
    }
}
