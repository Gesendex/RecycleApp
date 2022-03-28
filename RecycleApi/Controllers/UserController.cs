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

        [ProducesResponseType(typeof(IEnumerable<AuthenticateResponse>), StatusCodes.Status200OK)]
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

        [ProducesResponseType(typeof(IEnumerable<ApiClientDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("Registration")]
        public async Task<ActionResult<ApiClientDtoOut>> Registration([FromBody] ApiClientDtoOut newClient)
        {
            /*if(newClient.Password == null || newClient.Email == null || 
                (await db.Roles.FindAsync( newClient.IdRole).AsTask()) == null || 
                newClient.Name == null)
                return BadRequest();
            newClient.Id = 0;
            try
            {
                var a = await db.Clients.AddAsync(newClient);
                await db.SaveChangesAsync();
                return Ok(a.Entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            */
            throw new NotImplementedException();
        }
    }
}
