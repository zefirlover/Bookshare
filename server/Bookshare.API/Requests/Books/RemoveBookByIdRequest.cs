using Microsoft.AspNetCore.Mvc;

namespace Bookshare.API.Requests.Books
{
    public class RemoveBookByIdRequest
    {
        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
    }
}
