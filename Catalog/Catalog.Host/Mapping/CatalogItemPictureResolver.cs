using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping;

public class CatalogItemPictureResolver : IMemberValueResolver<Mobile, MobileDto, string, string>
{
    private readonly CatalogConfig _config;

    public CatalogItemPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public string Resolve(Mobile source, MobileDto destination, string sourceMember, string destMember, ResolutionContext context)
    {
        return $"{_config.CdnHost}/{_config.ImgUrl}/{sourceMember}";
    }
}