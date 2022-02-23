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
    public class RoleDbRepository : IRoleRepository
    {
        RecycleContext db;
        public RoleDbRepository(RecycleContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var result = await db.Roles.ToListAsync();
            return result;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            var result = await db.Roles.FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }
    }
}
