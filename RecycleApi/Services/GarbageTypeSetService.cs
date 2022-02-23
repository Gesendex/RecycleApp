using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;

namespace RecycleApi.Services
{
    public class GarbageTypeSetService : IGarbageTypeSetService
    {
        IGarbageTypeSetReposytory garbageTypeSetReposytory;
        public GarbageTypeSetService(IGarbageTypeSetReposytory garbageTypeSetReposytory)
        {
            this.garbageTypeSetReposytory = garbageTypeSetReposytory;
        }
        public async Task<IEnumerable<GarbageTypeSet>> GetAllAsync()
        {
            var result = await garbageTypeSetReposytory.GetAllAsync();
            return result;
        }

        public async Task<IEnumerable<GarbageTypeSet>> GetByGarbageCollectionPointeIdAsync(int id)
        {
            var result = await garbageTypeSetReposytory.GetByGarbageCollectionPointeIdAsync(id);
            return result;
        }

        public async Task<IEnumerable<GarbageTypeSet>> GetByTypeOfGarbageIdAsync(int id)
        {
            var result = await garbageTypeSetReposytory.GetByTypeOfGarbageIdAsync(id);
            return result;
        }
    }
}
