using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Services
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetAllAsync();
        public Task<Company> GetByIdAsync(int id);
    }
}
