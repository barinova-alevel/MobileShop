namespace Catalog.Host.Data.Entities
{
    public class MobileOs : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
