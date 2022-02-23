using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetAllAsync();
        public Task<Company> GetByIdAsync(int id);
    }
}
