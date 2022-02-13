using AutoMapper;
using Catalog.Host.Configurations;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Mapping
{
    public class PictureResolver<T, TDto> : IMemberValueResolver<T, TDto, string, string>
    {
        private readonly CatalogConfig _config;
        private readonly string _folder;

        public PictureResolver(string folder, IOptionsSnapshot<CatalogConfig> config)
        {
            _config = config.Value;
            _folder = folder;
        }

        public string Resolve(T source, TDto destination, string sourceMember, string destMember, ResolutionContext context)
        {
            return $"{_config.CdnHost}/{_config.ImgUrl}/{_folder}/{sourceMember}";
        }
    }
}
