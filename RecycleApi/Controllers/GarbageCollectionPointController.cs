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
            return await db.GarbageCollectionPoints.Include(p => p.IdCompanyNavigation).Include(p => p.GarbageTypeSets).ToArrayAsync();
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
        [HttpGet("GetByClientId/{id}")]
        public async Task<IEnumerable<GarbageCollectionPoint>> GetByClientId(int id)
        {
            return await db.GarbageCollectionPoints.Include(p => p.IdCompanyNavigation).Where(p => p.IdCompanyNavigation.ClientId == id).ToListAsync();
        }
        [HttpPost("Update")]
        public async Task<ActionResult> Update([FromBody] GarbageCollectionPoint model)
        {
            if (string.IsNullOrWhiteSpace(model.Street) || string.IsNullOrWhiteSpace(model.Building) 
                || await db.Companies.FindAsync(model.IdCompany)==null)
            {
                return BadRequest();
            }
            var fromDB = await db.GarbageCollectionPoints.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (fromDB == null)
                return NotFound();
            try
            {
                db.GarbageTypeSets.RemoveRange(db.GarbageTypeSets.Where(p => p.IdGarbageCollectionPoint == model.Id));
                await db.SaveChangesAsync();
                fromDB.GarbageTypeSets = model.GarbageTypeSets;
                fromDB.IdCompany = model.IdCompany;
                fromDB.Image = model.Image;
                fromDB.Street = model.Street;
                fromDB.Building = model.Building;
                fromDB.Description = model.Description;
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
        [HttpPut("CreateGCP")]
        public async Task<ActionResult<GarbageCollectionPoint>> CreateGCP([FromBody] GarbageCollectionPoint gcp)
        {
            if (gcp == null)
                return BadRequest();
            if (await db.Companies.FindAsync(gcp.IdCompany) == null || string.IsNullOrWhiteSpace(gcp.Street)
                || string.IsNullOrWhiteSpace(gcp.Building))
            {
                return BadRequest();
            }
            try
            {
                gcp.Id = 0;
                var newField = await db.GarbageCollectionPoints.AddAsync(gcp);
                await db.SaveChangesAsync();
                return (newField.Entity);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}

