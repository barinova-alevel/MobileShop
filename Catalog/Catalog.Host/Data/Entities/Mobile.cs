namespace Catalog.Host.Data.Entities
{
    public class Mobile : IBaseEntity, IDevice
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = null!;

        public int MobileBrandId { get; set; }

        public MobileBrand MobileBrand { get; set; } = null!;

        public int OperationSystemId { get; set; }

        public MobileOs OperationSystem { get; set; } = null!;

        public int AvailableStock { get; set; }

        public string Sku { get; set; } = null!;
    }
}
