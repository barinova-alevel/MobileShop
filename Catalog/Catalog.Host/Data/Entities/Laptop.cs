namespace Catalog.Host.Data.Entities
{
    public class Laptop : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PictureFileName { get; set; } = null!;

        public int LaptopBrandId { get; set; }

        public LaptopBrand LaptopBrand { get; set; } = null!;

        public int ScreenTypeId { get; set; }

        public LaptopScreenType ScreenType { get; set; } = null!;

        public int AvailableStock { get; set; }
    }
}
