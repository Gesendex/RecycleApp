using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleApi.Authorization;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [ProducesResponseType(typeof(IEnumerable<ApiRoleDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roleService.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(ApiRoleDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _roleService.GetByIdAsync(id);
            return Ok(result);
        }
    }
}