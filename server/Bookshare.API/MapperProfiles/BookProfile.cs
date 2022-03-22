using System.Collections.Generic;
using AutoMapper;
using Bookshare.API.Requests.Books;
using Bookshare.API.Responses.Books;
using Bookshare.ApplicationServices.Commands.BookCommands;
using Bookshare.ApplicationServices.Queries.BookQueries;
using Bookshare.Domain.Models;

namespace Bookshare.API.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            // Book: add
            CreateMap<AddBookRequest, AddBookCommand>();

            // Book: read
            CreateMap<GetBookByIdRequest, GetBookByIdQuery>();
            CreateMap<Book, GetBookByIdResponse>();
            CreateMap<GetBooksRequest, GetBooksQuery>();
            CreateMap<List<Book>, GetBooksResponse>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(x => x));

            // Book: update
            CreateMap<UpdateBookByIdRequest, UpdateBookCommand>();
            CreateMap<Book, UpdateBookResponse>();

            // Book: remove
            CreateMap<RemoveBookByIdRequest, RemoveBookByIdCommand>();
        }
    }
}
