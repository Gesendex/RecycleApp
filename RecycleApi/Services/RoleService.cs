using Recycle.Interfaces.Repositories;
using RecycleApi.Converter;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IList<ApiRoleDtoOut>> GetAllAsync()
        {
            var result = await _roleRepository.GetAllAsync();
            return result
                .Select(RoleConverter.ToApi)
                .ToList();
        }

        public async Task<ApiRoleDtoOut> GetByIdAsync(int id)
        {
            var result = await _roleRepository.GetByIdAsync(id);
            return RoleConverter.ToApi(result);
        }
    }
}