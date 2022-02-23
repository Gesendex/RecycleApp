using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Repositories
{
    public interface IGarbageTypeSetReposytory
    {
        Task<IEnumerable<GarbageTypeSet>> GetAllAsync();
        Task<IEnumerable<GarbageTypeSet>> GetByTypeOfGarbageIdAsync(int id);
        Task<IEnumerable<GarbageTypeSet>> GetByGarbageCollectionPointeIdAsync(int id);
    }
}
