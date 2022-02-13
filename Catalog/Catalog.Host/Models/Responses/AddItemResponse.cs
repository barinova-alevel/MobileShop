namespace Catalog.Host.Models.Responses
{
    public class AddItemResponse<T>
    {
        public T Id { get; set; } = default(T)!;
    }
}
