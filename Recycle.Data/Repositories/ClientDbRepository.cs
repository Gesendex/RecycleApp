using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Repositories;
using Recycle.Models;
using Recycle.Models.AuthorizationModels;

namespace Recycle.Data.Repositories
{
    public class ClientDbRepository : IClientRepository
    {
        private readonly RecycleContext _db;
        public ClientDbRepository(RecycleContext db)
        {
            _db = db;
        }
        public async Task AddClientAsync(Client client) => await _db.Clients.AddAsync(client);

        public async Task<Client> GetClientAsync(int id) => await _db.Clients.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Client> GetClientAsync(AuthorizationBody credentials)
        {
            return await Task.FromResult(
                _db.Clients
                .SingleOrDefault(
                    client =>
                    client.Email == credentials.Email && 
                    client.Password == credentials.Password
                ));
        }

        public async Task<IEnumerable<Client>> GetClientsAsync() => await _db.Clients.ToListAsync();
    }

}
