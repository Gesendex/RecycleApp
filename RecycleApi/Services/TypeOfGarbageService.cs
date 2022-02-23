using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class TypeOfGarbageService : ITypeOfGarbageService
    {
        private ITypeOfGarbageRepository typeOfGarbageRepository;
        public TypeOfGarbageService(ITypeOfGarbageRepository typeOfGarbageRepository)
        {
            this.typeOfGarbageRepository = typeOfGarbageRepository;
        }
        public async Task<IEnumerable<TypeOfGarbage>> GetAllAsync()
        {
            return await typeOfGarbageRepository.GetAllAsync();
        }

        public async Task<IEnumerable<TypeOfGarbage>> GetAllWithImageAsync()
        {
            return await typeOfGarbageRepository.GetAllWithImageAsync();
        }

        public async Task<IEnumerable<TypeOfGarbage>> GetByGarbageCollectionPointIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TypeOfGarbage> GetByIdAsync(int id)
        {
            return await typeOfGarbageRepository.GetByIdAsync(id);
        }

        public async Task<TypeOfGarbage> GetByIdWithImageAsync(int id)
        {
            return await GetByIdWithImageAsync(id);
        }
    }
}
