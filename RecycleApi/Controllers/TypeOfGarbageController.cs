using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recycle.Models;
using RecycleApi.Authorization;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfGarbageController : ControllerBase
    {
        private readonly ITypeOfGarbageService _typeOfGarbageService;

        public TypeOfGarbageController(ITypeOfGarbageService typeOfGarbageService)
        {
            _typeOfGarbageService = typeOfGarbageService;
        }

        [ProducesResponseType(typeof(IEnumerable<ApiTypeOfGarbageDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _typeOfGarbageService.GetAllAsync();
            return Ok(res);
        }

        [ProducesResponseType(typeof(IEnumerable<ApiTypeOfGarbageDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAllWithImage")]
        public async Task<IActionResult> GetAllWithImage()
        {
            var res = await _typeOfGarbageService.GetAllWithImageAsync();
            return Ok(res);
        }

        [ProducesResponseType(typeof(TypeOfGarbage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _typeOfGarbageService.GetByIdAsync(id);
            return Ok(res);
        }
    }
}
