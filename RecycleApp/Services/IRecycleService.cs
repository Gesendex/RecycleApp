using RecycleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleApp.Services
{
    public interface IRecycleService
    {
        Task<ClientDtoIn> AuthorizeAsync(AuthorizationBodyDtoIn credentials);
    }
}
