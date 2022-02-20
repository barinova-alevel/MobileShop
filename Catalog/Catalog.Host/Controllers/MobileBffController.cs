using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    public class MobileBffController : ControllerBase
    {
        private readonly IMobileService _mobileService;
        private readonly IMobileBrandService _mobileBrandService;
        private IMobileOsService _mobileOsService;
        public MobileBffController(
        IMobileService mobileService,
        IMobileBrandService brandService,
        IMobileOsService mobileOsService)
        {
            _mobileService = mobileService;
            _mobileBrandService = brandService;
            _mobileOsService = mobileOsService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<MobileDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Mobiles(PaginatedItemsRequest<MobileFilter> request)
        {
            var result = await _mobileService.GetMobileAsync(request.Filter, request.PageSize, request.PageIndex);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MobileDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Mobile(IdRequest request)
        {
            var result = await _mobileService.GetById(request.Id!.Value);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<MobileBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Brands()
        {
            var result = await _mobileBrandService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<MobileOsDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> OperationSystems()
        {
            var result = await _mobileOsService.GetAllAsync();
            return Ok(result);
        }
    }
}
