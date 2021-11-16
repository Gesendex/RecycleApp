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
        #endregion
    }
}
