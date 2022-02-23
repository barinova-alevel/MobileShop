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
    [Scope("catalog.mobile.os")]
    public class MobileOsController : ControllerBase
    {
        private readonly IMobileOsService _osService;
        private readonly ILogger<MobileOsController> _logger;

        public MobileOsController(IMobileOsService osService, ILogger<MobileOsController> logger)
        {
            this._osService = osService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Add(CreateOperationSystemRequest request)
        {
            var result = await _osService.AddAsync(request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(UpdateOperationSystemRequest request)
        {
            var result = await _osService.UpdateAsync(request.Id!.Value, request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _osService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
