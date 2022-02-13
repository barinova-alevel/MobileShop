namespace Catalog.Host.Data.Entities
{
    public class LaptopScreenType : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
