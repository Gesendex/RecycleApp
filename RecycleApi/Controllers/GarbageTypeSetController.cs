using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Services;
using Recycle.Models;
using RecycleApi.Authorization;
using RecycleApi.Models;
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

        [ProducesResponseType(typeof(IEnumerable<ApiGarbageTypeSetDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _garbageTypeSetService.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(ApiGarbageTypeSetDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetByTypeOfGarbageId/{id}")]
        public async Task<IActionResult> GetByTypeOfGarbageId(int id)
        {
            var result = await _garbageTypeSetService.GetByTypeOfGarbageIdAsync(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ApiGarbageTypeSetDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetByGarbageCollectionPointeId/{id}")]
        public async Task<IActionResult> GetByGarbageCollectionPointeId(int id)
        {
            var result = await _garbageTypeSetService.GetByGarbageCollectionPointeIdAsync(id);
            return Ok(result);
        }
    }
}
