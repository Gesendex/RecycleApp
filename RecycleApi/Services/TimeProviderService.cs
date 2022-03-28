using RecycleApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class TimeProviderService : ITimeProviderService
    {
        public DateTime CurrentDateTime => DateTime.Now;
    }
}
