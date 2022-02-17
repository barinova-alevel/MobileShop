using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [Route(ComponentDefaults.DefaultRoute)]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly ILogger<MobileController> _logger;
        private readonly IMobileService _mobileService;

        public MobileController(
            ILogger<MobileController> logger,
            IMobileService mobileService)
        {
            _logger = logger;
            _mobileService = mobileService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateMobileRequest request)
        {
            var result = await _mobileService.AddAsync(request.Name, request.Description, request.Price, request.PictureFileName, request.BrandId, request.OperationSystemId, request.AvailableStock);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdateMobileRequest request)
        {
            var result = await _mobileService.UpdateAsync(request.Id, request.Name, request.Description, request.Price, request.PictureFileName, request.BrandId, request.OperationSystemId, request.AvailableStock);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _mobileService.RemoveAsync(request.Id);
            return NoContent();
        }
    }
}
