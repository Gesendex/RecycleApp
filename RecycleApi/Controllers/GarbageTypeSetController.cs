using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Models;
using RecycleApi.Authorization;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarbageTypeSetController : ControllerBase
    {

        private readonly IGarbageTypeSetService _garbageTypeSetService;

        public GarbageTypeSetController(IGarbageTypeSetService garbageTypeSetService)
        {
            _garbageTypeSetService = garbageTypeSetService;
        }

        [ProducesResponseType(typeof(IList<ApiGarbageTypeSetDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _garbageTypeSetService.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(ApiGarbageTypeSetDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetByTypeOfGarbageId/{id}")]
        public async Task<IActionResult> GetByTypeOfGarbageId(int id)
        {
            var result = await _garbageTypeSetService.GetByTypeOfGarbageIdAsync(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IList<ApiGarbageTypeSetDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetByGarbageCollectionPointeId/{id}")]
        public async Task<IActionResult> GetByGarbageCollectionPointId(int id)
        {
            var result = await _garbageTypeSetService.GetByGarbageCollectionPointIdAsync(id);
            return Ok(result);
        }
    }
}
