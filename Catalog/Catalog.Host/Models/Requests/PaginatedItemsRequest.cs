namespace Catalog.Host.Models.Requests;

public class PaginatedItemsRequest<T> where T : class, new()
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public T Filter { get; set; } = new();
}