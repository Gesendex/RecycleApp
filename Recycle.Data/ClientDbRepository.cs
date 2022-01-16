using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces;
using Recycle.Models;

namespace Recycle.Data
{
    public class ClientDbRepository : IClientRepository
    {
        private readonly RecycleContext _db;
        public ClientDbRepository(RecycleContext db)
        {
            _db = db;
        }
        public async Task AddClientAsync(Client client)
        {
            await _db.Clients.AddAsync(client);
        }

        public Task<Client> GetClientAsync(int id)
        {
            return _db.Clients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _db.Clients.ToListAsync();
        }
    }
}
