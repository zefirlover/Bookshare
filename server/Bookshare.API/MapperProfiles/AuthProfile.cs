using AutoMapper;
using Bookshare.API.Requests.Auth;
using Bookshare.API.Responses.Auth;
using Bookshare.ApplicationServices.Commands.Auth;
using Bookshare.ApplicationServices.JwtAuthService.ResultModels;

namespace Bookshare.API.MapperProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterNewUserRequest, RegisterNewUserCommand>();
            CreateMap<LoginRequest, LoginCommand>();
            CreateMap<LoginResult, LoginResponse>();
            CreateMap<RefreshTokenResult, RefreshTokenResponse>();
        }
    }
}
