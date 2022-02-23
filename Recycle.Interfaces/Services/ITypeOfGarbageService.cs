using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Services
{
    public interface ITypeOfGarbageService
    {
        public Task<IEnumerable<TypeOfGarbage>> GetAllAsync();
        public Task<IEnumerable<TypeOfGarbage>> GetAllWithImageAsync();
        public Task<IEnumerable<TypeOfGarbage>> GetByGarbageCollectionPointIdAsync(int id);

        public Task<TypeOfGarbage> GetByIdAsync(int id);
        public Task<TypeOfGarbage> GetByIdWithImageAsync(int id);

    }
}
