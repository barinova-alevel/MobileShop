using System.Security.Claims;
using Basket.Host.Entities;

namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
    Task<ShoppingCart> SetAsync(ClaimsPrincipal principal, List<ShoppingCartItem> items);
    Task<ShoppingCart> GetAsync(ClaimsPrincipal principal);
    Task<bool> DeleteAsync(ClaimsPrincipal principal);
}