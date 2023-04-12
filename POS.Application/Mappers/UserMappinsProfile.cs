using AutoMapper;
using SAM.Application.DTOS.Request;
using SAM.Application.DTOS.Response;
using SAM.Domain.Entities;
using SAM.Infrastructure.Commons.Bases.Response;

namespace SAM.Application.Mappers
{
    public class UserMappinsProfile : Profile
    {
        public UserMappinsProfile()
        {
            CreateMap<User, UserResponseDTO>()
                .ForMember(x => x.Status, x => x.MapFrom(y => y.IsActive == true ? "Active" : "Inactive"))
                .ReverseMap();
            CreateMap<UserRequestDTO, User>();
            CreateMap<TokenRequestDTO, User>();
        }
    }
}
