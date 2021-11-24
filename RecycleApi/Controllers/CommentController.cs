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
    public class CommentController : ControllerBase
    {
        RecycleContext db;
        public CommentController(RecycleContext db)
        {
            this.db = db;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await db.Comments.ToListAsync();
        }
        [HttpGet("GetById/{id}")]
        public async Task<Comment> GetById(int id)
        {
            return await db.Comments.FirstOrDefaultAsync(p => p.Id == id);
        }
        [HttpGet("GetAllByClientId/{id}")]
        public async Task<IEnumerable<Comment>> GetAllByClientId(int id)
        {
            return await db.Comments.Include(p => p.IdClientNavigation).Where(p=>p.IdClient == id).ToListAsync();
        }

        [HttpGet("GetAllByGCPId/{id}")]
        public async Task<IEnumerable<Comment>> GetAllByGCPtId(int id)
        {
            return await db.Comments.Include(p => p.IdClientNavigation).Where(p => p.IdGarbageCollectionPoint == id).ToListAsync();
        }
        #endregion
    }
}
