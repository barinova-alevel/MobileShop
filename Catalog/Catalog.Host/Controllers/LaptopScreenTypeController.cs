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
    [Scope("catalog.laptop.screentype")]
    public class LaptopScreenTypeController : ControllerBase
    {
        private readonly ILaptopScreenTypeService _screenTypeService;
        private readonly ILogger<LaptopScreenTypeController> _logger;

        public LaptopScreenTypeController(ILaptopScreenTypeService screenTypeService, 
                                          ILogger<LaptopScreenTypeController> logger)
        {
            _screenTypeService = screenTypeService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Add(CreateScreenTypeRequest request)
        {
            var result = await _screenTypeService.AddAsync(request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdateScreenTypeRequest request)
        {
            var result = await _screenTypeService.UpdateAsync(request.Id!.Value, request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _screenTypeService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
