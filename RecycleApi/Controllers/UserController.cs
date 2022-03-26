using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Services;
using Recycle.Models;
using Recycle.Models.AuthorizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] AuthorizationBody  credentials )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _authorizationService.Authorize(credentials);

            return user == null 
                ? NotFound() 
                : Ok(user);
        }

        [HttpPut("Registration")]
        public async Task<ActionResult<Client>> Registration([FromBody] Client newClient)
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
