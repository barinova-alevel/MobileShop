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
    public class LaptopBffController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        private readonly ILaptopBrandService _brandService;
        private readonly ILaptopScreenTypeService _screenTypeService;

        public LaptopBffController(
        ILaptopService laptopService,
        ILaptopBrandService brandService,
        ILaptopScreenTypeService screenTypeService)
        {
            _laptopService = laptopService;
            this._brandService = brandService;
            _screenTypeService = screenTypeService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PaginatedItemsResponse<LaptopDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Laptops(PaginatedItemsRequest<LaptopFilter> request)
        {
            var result = await _laptopService.GetLaptopsAsync(request.Filter, request.PageSize, request.PageIndex);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(MobileDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Laptop(IdRequest request)
        {
            var result = await _laptopService.GetById(request.Id!.Value);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<LaptopBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Brands()
        {
            var result = await _brandService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<LaptopScreenTypeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ScreenTypes()
        {
            var result = await _screenTypeService.GetAllAsync();
            return Ok(result);
        }
    }
}
