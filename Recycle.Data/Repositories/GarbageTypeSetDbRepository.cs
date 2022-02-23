using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Repositories;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Data.Repositories
{
    public class GarbageTypeSetDbRepository : IGarbageTypeSetReposytory
    {
        RecycleContext db;
        public GarbageTypeSetDbRepository(RecycleContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<GarbageTypeSet>> GetAllAsync()
        {
            var result = await db.GarbageTypeSets.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GarbageTypeSet>> GetByGarbageCollectionPointeIdAsync(int id)
        {
            var result = await db.GarbageTypeSets.Where(p => p.IdGarbageCollectionPoint == id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<GarbageTypeSet>> GetByTypeOfGarbageIdAsync(int id)
        {
            var result = await db.GarbageTypeSets.Where(p => p.IdTypeOfGarbage == id).ToListAsync();
            return result;
        }
    }
}
