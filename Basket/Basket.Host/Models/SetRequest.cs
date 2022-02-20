using Basket.Host.Entities;
using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models;

public class SetRequest
{
    [Required] 
    public List<ShoppingCartItem> Data { get; set; } = null!;
}