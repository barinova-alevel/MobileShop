namespace Catalog.Host.Models.Dtos
{
    public class MobileDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = null!;
        
        public MobileBrandDto MobileBrand { get; set; } = null!;

        public MobileOsDto OperationSystem { get; set; } = null!;

        public int AvailableStock { get; set; }
        public string Sku { get; set; } = null!;
    }
}
