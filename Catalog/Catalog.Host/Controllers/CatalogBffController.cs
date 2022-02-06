using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogBffController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatalogBffController(
        ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<MobileDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Mobiles(PaginatedItemsRequest<MobileFilter> request)
        {
            var result = await _catalogService.GetCatalogItemsAsync(request.Filter, request.PageSize, request.PageIndex);
            return Ok(result);
        }
    }
}
