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
    [Scope("catalog.laptop")]
    public class LaptopController : ControllerBase
    {
        private readonly ILogger<LaptopController> _logger;
        private readonly ILaptopService _laptopService;

        public LaptopController(
            ILogger<LaptopController> logger,
            ILaptopService laptopService)
        {
            _logger = logger;
            _laptopService = laptopService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateLaptopRequest request)
        {
            var result = await _laptopService.AddAsync(request.Name, 
                request.Description, 
                request.Price!.Value, 
                request.PictureFileName, 
                request.BrandId!.Value, 
                request.ScreenTypeId!.Value, 
                request.AvailableStock,
                request.Sku);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdateLaptopRequest request)
        {
            var result = await _laptopService.UpdateAsync(request.Id!.Value, 
                request.Name, 
                request.Description, 
                request.Price!.Value, 
                request.PictureFileName, 
                request.BrandId!.Value, 
                request.ScreenTypeId!.Value, 
                request.AvailableStock);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _laptopService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
