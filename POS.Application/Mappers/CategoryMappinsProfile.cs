using AutoMapper;
using SAM.Application.DTOS.Request;
using SAM.Application.DTOS.Response;
using SAM.Domain.Entities;
using SAM.Infrastructure.Commons.Bases.Response;

namespace SAM.Application.Mappers
{
    public class CategoryMappinsProfile : Profile
    {
        public CategoryMappinsProfile()
        {
            CreateMap<Category, CategoryResponseDTO>()
                .ForMember(x => x.Status, x => x.MapFrom(y => y.IsActive == true ? "Active" : "Inactive"))
                .ReverseMap();
            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDTO>>()
                .ReverseMap();
            CreateMap<CategoryRequestDTO, Category>();
            CreateMap<Category, CategorySelectResponseDTO>()
                .ReverseMap();
        }
    }
}
