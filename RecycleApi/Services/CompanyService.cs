using Recycle.Models;
using RecycleApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recycle.Interfaces.Repositories;
using RecycleApi.Converter;
using RecycleApi.Models;

namespace RecycleApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IList<ApiCompanyDtoOut>> GetAllAsync()
        {
            var result = await _companyRepository.GetAllAsync();

            return result
                .Select(CompanyConverter.ToApi)
                .ToList();
        }

        public async Task<ApiCompanyDtoOut> GetByIdAsync(int id)
        {
            var result = await _companyRepository.GetByIdAsync(id);

            return CompanyConverter.ToApi(result);
        }

        public async Task<ApiCompanyDtoOut> GetByClientIdAsync(int id)
        {
	        var result = await _companyRepository.GetByClientIdAsync(id);

	        return CompanyConverter.ToApi(result);
        }
    }
}