using RecycleApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Services.Interfaces
{
    public interface IRoleService
    {
        public Task<IList<ApiRoleDtoOut>> GetAllAsync();

        public Task<ApiRoleDtoOut> GetByIdAsync(int id);
    }
}
