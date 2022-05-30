using RecycleApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<IList<ApiCompanyDtoOut>> GetAllAsync();

        public Task<ApiCompanyDtoOut> GetByIdAsync(int id);

        public Task<ApiCompanyDtoOut> GetByClientIdAsync(int id);
    }
}
