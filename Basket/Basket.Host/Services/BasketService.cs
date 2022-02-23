using System.Security.Claims;
using Basket.Host.Entities;
using Basket.Host.Extensions;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;

    public BasketService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<ShoppingCart> SetAsync(ClaimsPrincipal principal, List<ShoppingCartItem> items)
    {
        var basket = new ShoppingCart { Items = items };
        await _cacheService.AddOrUpdateAsync(principal.GetUserId(), basket);
        return basket;
    }

    public async Task<ShoppingCart> GetAsync(ClaimsPrincipal principal)
    {
        return (await _cacheService.GetAsync<ShoppingCart>(principal.GetUserId())) ?? ShoppingCart.Empty;
    }

    public async Task<bool> DeleteAsync(ClaimsPrincipal principal)
    {
        return await _cacheService.DeleteAsync(principal.GetUserId());
    }
}