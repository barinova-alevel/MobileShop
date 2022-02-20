using Basket.Host.Entities;
using System.Security.Claims;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task<ShoppingCart> SetAsync(ClaimsPrincipal principal, List<ShoppingCartItem> items);
    Task<ShoppingCart> GetAsync(ClaimsPrincipal principal);
    Task<bool> DeleteAsync(ClaimsPrincipal principal);
}