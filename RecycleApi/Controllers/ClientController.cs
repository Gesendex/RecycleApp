using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        RecycleContext db;
        public ClientController(RecycleContext db)
        {
            this.db = db;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await db.Clients.ToListAsync();
        }
        [HttpGet("GetById/{id}")]
        public async Task<Client> GetById(int id)
        {
            return await db.Clients.FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpPost("Authorization")]
        public async Task<ActionResult<Client>> Authorization([FromBody] string[] clientData )
        {
            if (clientData == null || clientData.Length != 2)
                return BadRequest();
            if(clientData[0].Length < 6 || clientData[1].Length < 6)
                return BadRequest();
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
                await db.Clients.AddAsync(newClient);
                await db.SaveChangesAsync();
                return Ok(await db.Clients.FirstOrDefaultAsync(p => p.Email == newClient.Email));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
        #endregion
    }
}
