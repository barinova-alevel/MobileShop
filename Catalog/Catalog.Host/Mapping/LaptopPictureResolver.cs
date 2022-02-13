using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping;

public class LaptopPictureResolver : PictureResolver<Laptop, LaptopDto>
{
    public LaptopPictureResolver(IOptionsSnapshot<CatalogConfig> config): base("laptop", config)
    {
    }
}
