using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces
{
    interface IClientService
    {
        public Task Registration(Client client);
        public Task Authorization(Client client);

    }
}
