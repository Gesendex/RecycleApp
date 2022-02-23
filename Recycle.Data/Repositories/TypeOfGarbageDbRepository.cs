using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recycle.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Recycle.Data.Repositories
{
    public class TypeOfGarbageDbRepository : ITypeOfGarbageRepository
    {
        private RecycleContext db;
        public TypeOfGarbageDbRepository(RecycleContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<TypeOfGarbage>> GetAllAsync()
        {
            return await db.TypeOfGarbages.ToListAsync();
        }

        public async Task<IEnumerable<TypeOfGarbage>> GetAllWithImageAsync()
        {
            return await db.TypeOfGarbages.Include(p => p.TypeImage).ToListAsync();
        }

        public async Task<TypeOfGarbage> GetByIdAsync(int id)
        {
            return await db.TypeOfGarbages.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<TypeOfGarbage> GetByIdWithImageAsync(int id)
        {
            return await db.TypeOfGarbages.Include(p => p.TypeImage).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
