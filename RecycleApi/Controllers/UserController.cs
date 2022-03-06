using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        RecycleContext db;
        public UserController(RecycleContext db)
        {
            this.db = db;
        }

        [HttpPost("Authorization")]
        public async Task<ActionResult<Client>> Authorization([FromBody] AuthorizationBody  credentials )
        {
            if (credentials.Email == null || credentials.Password == null)
                return Unauthorized("Неправильный логин или пароль!");
            var user = await db.Clients.FirstOrDefaultAsync(p => p.Email == clientData[0] && p.Password == clientData[1]);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("Registration")]
        public async Task<ActionResult<Client>> Registration([FromBody] Client newClient)
        {
            if(newClient.Password == null || newClient.Email == null || 
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
            
        }
    }
}
