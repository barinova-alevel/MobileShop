namespace Catalog.Host.Models.Dtos
{
    public class MobileDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = null!;

        public BrandDto Brand { get; set; } = null!;  

        public OperationSystemDto OperationSystem { get; set; } = null!;

        public int AvailableStock { get; set; }
    }

    public class MobileFilter
    {
        public int? BrandId { get; set; }
        public int? OperationSystemId { get; set; }
    }
}
