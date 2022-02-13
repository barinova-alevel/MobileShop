using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping;

public class MobilePictureResolver : PictureResolver<Mobile, MobileDto>
{
    public MobilePictureResolver(IOptionsSnapshot<CatalogConfig> config) : base("mobile", config)
    {
    }
}