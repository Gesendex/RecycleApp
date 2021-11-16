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
    public class CompanyController : ControllerBase
    {
        RecycleContext db;
        public CompanyController(RecycleContext db)
        {
            this.db = db;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await db.Companies.ToListAsync();
        }
        [HttpGet("GetById/{id}")]
        public async Task<Company> GetByIdAsync(int id)
        {
            return await db.Companies.FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion
    }
}
