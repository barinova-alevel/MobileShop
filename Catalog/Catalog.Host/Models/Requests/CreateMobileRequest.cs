namespace Catalog.Host.Models.Requests
{
    public class CreateMobileRequest
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = null!;

        public int BrandId { get; set; }

        public int OperationSystemId { get; set; }

        public int AvailableStock { get; set; }
    }
}
