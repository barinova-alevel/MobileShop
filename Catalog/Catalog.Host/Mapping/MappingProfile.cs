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
                => opt.MapFrom<MobilePictureResolver, string>(c => c.PictureFileName));
        CreateMap<MobileBrand, MobileBrandDto>();
        CreateMap<MobileOs, MobileOsDto>();

        CreateMap<Laptop, LaptopDto>()
            .ForMember(_ => _.PictureUrl, opt
                => opt.MapFrom<LaptopPictureResolver, string>(c => c.PictureFileName));
        CreateMap<LaptopBrand, LaptopBrandDto>();
        CreateMap<LaptopScreenType, LaptopScreenTypeDto>();
    }
}