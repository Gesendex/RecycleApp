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
    public class GarbageTypeSetController : ControllerBase
    {
        RecycleContext db;
        public GarbageTypeSetController(RecycleContext db)
        {
            this.db = db;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<GarbageTypeSet>> GetAll()
        {
            return await db.GarbageTypeSets.ToListAsync();
        }
        [HttpGet("GetByTypeOfGarbageId/{id}")]
        public async Task<IEnumerable<GarbageTypeSet>> GetByTypeOfGarbageId(int id)
        {
            return await db.GarbageTypeSets.Where(p=>p.IdTypeOfGarbage == id).ToListAsync();
        }
        [HttpGet("GetByGarbageCollectionPointeId/{id}")]
        public async Task<IEnumerable<GarbageTypeSet>> GetByGarbageCollectionPointeId(int id)
        {
            return await db.GarbageTypeSets.Where(p => p.IdGarbageCollectionPoint == id).ToListAsync();
        }
        #endregion
    }
}
