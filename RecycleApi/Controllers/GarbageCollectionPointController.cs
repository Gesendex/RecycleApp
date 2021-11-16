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
    public class GarbageCollectionPointController : ControllerBase
    {
        RecycleContext db;
        public GarbageCollectionPointController(RecycleContext db)
        {
            this.db = db;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<GarbageCollectionPoint>> GetAll()
        {
            return await db.GarbageCollectionPoints.ToArrayAsync();
        }
        [HttpGet("GetById/{id}")]
        public async Task<GarbageCollectionPoint> GetById(int id)
        {
            return await db.GarbageCollectionPoints.FirstOrDefaultAsync(p => p.Id == id);
        }
        [HttpGet("GetByTypeOfGarbageId/{id}")]
        public async Task<IEnumerable<GarbageCollectionPoint>> GetByTypeOfGarbageId(int id)
        {
            return await db.GarbageTypeSets.Where(p => p.IdTypeOfGarbage == id).Select(p => p.IdGarbageCollectionPointNavigation).ToListAsync();
        }
    }
}

