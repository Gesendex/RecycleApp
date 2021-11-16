using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfGarbageController : ControllerBase
    {
        RecycleContext db;
        public TypeOfGarbageController(RecycleContext db)
        {
            this.db = db;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<TypeOfGarbage>> GetAll()
        {
            return await db.TypeOfGarbages.ToListAsync();
        }
        [HttpGet("GetById/{id}")]
        public async Task<TypeOfGarbage> GetById(int id)
        {
            return await db.TypeOfGarbages.FirstOrDefaultAsync(p => p.Id == id);
        }
        [HttpGet("GetByCollectionPointId/{id}")]
        public async Task<IEnumerable<TypeOfGarbage>> GetByCollectionPointId(int id)
        {
            return await db.GarbageTypeSets.Where(p => p.IdGarbageCollectionPoint == id).Select(p => p.IdTypeOfGarbageNavigation).ToListAsync();
        }
        #endregion
    }
}
