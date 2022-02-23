using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Set(SetRequest data)
    {
        var basket = await _basketService.SetAsync(User, data.Data);
        return Ok(new GetResponse { Data = basket });
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        var basket = await _basketService.GetAsync(User);
        return Ok(new GetResponse { Data = basket });
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Delete()
    {
        await _basketService.DeleteAsync(User);
        return NoContent();
    }
}