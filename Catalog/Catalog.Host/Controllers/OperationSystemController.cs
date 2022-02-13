using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class OperationSystemController : ControllerBase
    {
        private readonly IMobileOsService _osService;
        private readonly ILogger<OperationSystemController> _logger;

        public OperationSystemController(IMobileOsService osService, ILogger<OperationSystemController> logger)
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
            var result = await _osService.UpdateAsync(request.Id, request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _osService.RemoveAsync(request.Id);
            return NoContent();
        }
    }
}
