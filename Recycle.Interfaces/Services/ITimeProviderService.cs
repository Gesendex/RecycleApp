using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Services
{
    public interface ITimeProviderService
    {
        public DateTime CurrentDateTime { get; }
    }
}
