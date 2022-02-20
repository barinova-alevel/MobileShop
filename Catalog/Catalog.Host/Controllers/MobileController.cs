using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
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
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
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
            var result = await _mobileService.AddAsync(request.Name, 
                request.Description, 
                request.Price!.Value, 
                request.PictureFileName, 
                request.BrandId!.Value, 
                request.OperationSystemId!.Value,
                request.AvailableStock,
                request.Sku);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdateMobileRequest request)
        {
            var result = await _mobileService.UpdateAsync(request.Id!.Value, 
                request.Name, 
                request.Description, 
                request.Price!.Value, 
                request.PictureFileName,
                request.BrandId!.Value, 
                request.OperationSystemId!.Value, 
                request.AvailableStock);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _mobileService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
