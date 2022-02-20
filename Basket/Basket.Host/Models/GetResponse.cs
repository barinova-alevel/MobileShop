using Basket.Host.Entities;

namespace Basket.Host.Models;

public class GetResponse
{
    public ShoppingCart Data { get; set; } = null!;
}