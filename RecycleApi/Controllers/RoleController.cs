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
    public class RoleController : ControllerBase
    {
        RecycleContext db;
        public RoleController(RecycleContext db)
        {
            this.db = db;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Role>> GetAll()
        {
            return await db.Roles.ToListAsync();
        }
        [HttpGet("GetById/{id}")]
        public async Task<Role> GetById(int id)
        {
            return await db.Roles.FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion
    }
}
