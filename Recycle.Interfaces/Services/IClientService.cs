using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Services
{
    interface IClientService
    {
        public Task Registration(Client client);
        public Task Authorization(string email, string password);

    }
}
