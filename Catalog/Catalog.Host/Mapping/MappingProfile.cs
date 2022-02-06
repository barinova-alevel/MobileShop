using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Mobile, MobileDto>()
            .ForMember(_ => _.PictureUrl, opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<Brand, BrandDto>();
        CreateMap<OperationSystem, OperationSystemDto>();
    }
}