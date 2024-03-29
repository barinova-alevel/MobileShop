﻿using Catalog.Host.Models.Requests;
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
    [Scope("catalog.mobile.brand")]
    public class MobileBrandController : ControllerBase
    {
        private readonly IMobileBrandService _brandService;
        private readonly ILogger<MobileBrandController> _logger;

        public MobileBrandController(IMobileBrandService brandService, ILogger<MobileBrandController> logger)
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
            var result = await _brandService.UpdateAsync(request.Id!.Value, request.Name);
            return Ok(new AddItemResponse<int?>() { Id = result });
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> Delete(IdRequest request)
        {
            await _brandService.RemoveAsync(request.Id!.Value);
            return NoContent();
        }
    }
}
