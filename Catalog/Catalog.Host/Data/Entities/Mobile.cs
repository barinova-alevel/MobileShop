namespace Catalog.Host.Data.Entities
{
    public class Mobile
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = null!;

        public int BrandId { get; set; }

        public Brand Brand { get; set; } = null!;

        public int OperationSystemId { get; set; }

        public OperationSystem OperationSystem { get; set; } = null!;

        public int AvailableStock { get; set; }
    }
}
