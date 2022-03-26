﻿using Recycle.Models;
using Recycle.Models.AuthorizationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Repositories
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClientsAsync();
        public Task AddClientAsync(Client client);
        public Task<Client> GetClientAsync(int id);
        public Task<Client> GetClientAsync(AuthorizationBody credentials);
    }
}
