using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class MobileBffController : ControllerBase
    {
        private readonly IMobileService _mobileService;
        private readonly IMobileBrandService _brandService;
        public MobileBffController(
        IMobileService mobileService,
        IMobileBrandService brandService)
        {
            _mobileService = mobileService;
            this._brandService = brandService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<MobileDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Mobiles(PaginatedItemsRequest<MobileFilter> request)
        {
            var result = await _mobileService.GetMobileAsync(request.Filter, request.PageSize, request.PageIndex);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<MobileBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Brands()
        {
            var result = await _brandService.GetAllAsync();
            return Ok(result);
        }
    }
}
