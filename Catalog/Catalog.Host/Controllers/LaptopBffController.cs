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
        [ProducesResponseType(typeof(PaginatedItemsResponse<LaptopDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Laptops(PaginatedItemsRequest<LaptopFilter> request)
        {
            var result = await _laptopService.GetLaptopsAsync(request.Filter, request.PageSize, request.PageIndex);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<LaptopBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Brands()
        {
            var result = await _brandService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<LaptopScreenTypeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ScreenTypes()
        {
            var result = await _screenTypeService.GetAllAsync();
            return Ok(result);
        }
    }
}
