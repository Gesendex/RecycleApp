using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class RoleService : IRoleService
    {
        IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var result = await roleRepository.GetAllAsync();
            return result;
        }
        public async Task<Role> GetByIdAsync(int id)
        {
            var result = await roleRepository.GetByIdAsync(id);
            return result;
        }
    }
}
