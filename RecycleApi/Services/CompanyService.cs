using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var result = await companyRepository.GetAllAsync();
            return result;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var result = await companyRepository.GetByIdAsync(id);
            return result;
        }
    }
}
