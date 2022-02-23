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
    public class CompanyDbRepository : ICompanyRepository
    {
        RecycleContext db;
        public CompanyDbRepository(RecycleContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var result = await db.Companies.ToListAsync();
            return result;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var result = await db.Companies.FirstOrDefaultAsync(p => p.Id == id);
            return result;
        }
    }
}
