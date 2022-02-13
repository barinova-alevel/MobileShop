namespace Catalog.Host.Data.Entities
{
    public class MobileBrand : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
