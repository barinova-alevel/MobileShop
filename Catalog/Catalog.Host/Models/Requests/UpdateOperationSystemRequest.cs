namespace Catalog.Host.Models.Requests
{
    public class UpdateOperationSystemRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
