using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Services;
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
        IGarbageTypeSetService GarbageTypeSetService;
        public GarbageTypeSetController(IGarbageTypeSetService GarbageTypeSetService)
        {
            this.GarbageTypeSetService = GarbageTypeSetService;
        }
        #region Get
        [HttpGet("GetAll")]
        public async Task<IEnumerable<GarbageTypeSet>> GetAll()
        {
            var result = await GarbageTypeSetService.GetAllAsync();
            return result;
        }
        [HttpGet("GetByTypeOfGarbageId/{id}")]
        public async Task<IEnumerable<GarbageTypeSet>> GetByTypeOfGarbageId(int id)
        {
            var result = await GarbageTypeSetService.GetByTypeOfGarbageIdAsync(id);
            return result;
        }
        [HttpGet("GetByGarbageCollectionPointeId/{id}")]
        public async Task<IEnumerable<GarbageTypeSet>> GetByGarbageCollectionPointeId(int id)
        {
            var result = await GarbageTypeSetService.GetByGarbageCollectionPointeIdAsync(id);
            return result;
        }
        #endregion
    }
}
