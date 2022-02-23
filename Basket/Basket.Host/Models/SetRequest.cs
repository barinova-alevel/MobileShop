using System.ComponentModel.DataAnnotations;
using Basket.Host.Entities;

namespace Basket.Host.Models;

public class SetRequest
{
    [Required]
    public List<ShoppingCartItem> Data { get; set; } = null!;
}