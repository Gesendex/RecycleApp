using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces
{
    public interface IClientRepository
    {
        public Task<IQueryable<Client>> GetClientsAsync();
        public Task AddClientAsync(Client client);
        public Task<Client> GetClientAsync(int id);
    }
}
