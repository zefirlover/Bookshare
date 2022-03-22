using System.Collections.Generic;
using AutoMapper;
using Bookshare.API.Requests.Libraries;
using Bookshare.API.Responses.Libraries;
using Bookshare.ApplicationServices.Commands.LibraryCommands;
using Bookshare.ApplicationServices.Queries.LibraryQueries;
using Bookshare.Domain.Models;

namespace Bookshare.API.MapperProfiles
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            // Library: add
            CreateMap<AddLibraryRequest, AddLibraryCommand>();

            // Library: read
            CreateMap<GetLibraryByIdRequest, GetLibraryByIdQuery>();
            CreateMap<Library, GetLibraryByIdResponse>();
            CreateMap<GetLibrariesRequest, GetLibrariesQuery>();
            CreateMap<List<Library>, GetLibrariesResponse>()
                .ForMember(dest => dest.Libraries, opt => opt.MapFrom(x => x));

            // Library: update
            CreateMap<UpdateLibraryByIdRequest, UpdateLibraryCommand>();
            CreateMap<Library, UpdateLibraryResponse>();
        }
    }
}
