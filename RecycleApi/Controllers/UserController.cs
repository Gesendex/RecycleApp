using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recycle.Models.AuthorizationModels;
using RecycleApi.Authorization;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public UserController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] AuthorizationBody credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _authorizationService.Authorize(credentials);

            return Ok(user);
        }

        [ProducesResponseType(typeof(ApiClientDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("Registration")]
        public async Task<IActionResult> Registration([FromBody] ApiClientDtoIn newClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _authorizationService.Registration(newClient);

            if (user == null)
            {
	            return BadRequest();
            }

            return Ok(user);
        }
    }
}
