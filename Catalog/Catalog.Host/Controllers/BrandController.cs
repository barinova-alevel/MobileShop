using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [Route(ComponentDefaults.DefaultRoute)]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMobileBrandService _brandService;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IMobileBrandService brandService, ILogger<BrandController> logger)
        {
            this._brandService = brandService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Add(CreateBrandRequest request)
        {
            var result = await _brandService.AddAsync(request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdateBrandRequest request)
        {
            var result = await _brandService.UpdateAsync(request.Id, request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _brandService.RemoveAsync(request.Id);
            return NoContent();
        }
    }
}
