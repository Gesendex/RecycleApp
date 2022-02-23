﻿using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Services
{
    public interface IRoleService
    {
        public Task<IEnumerable<Role>> GetAllAsync();
        public Task<Role> GetByIdAsync(int id);
    }
}
