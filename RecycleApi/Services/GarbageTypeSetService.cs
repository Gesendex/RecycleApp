using Recycle.Interfaces.Repositories;
using RecycleApi.Converter;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class GarbageTypeSetService : IGarbageTypeSetService
    {
        private readonly IGarbageTypeSetRepository _garbageTypeSetRepository;

        public GarbageTypeSetService(IGarbageTypeSetRepository garbageTypeSetRepository)
        {
            _garbageTypeSetRepository = garbageTypeSetRepository;
        }

        public async Task<IList<ApiGarbageTypeSetDtoOut>> GetAllAsync()
        {
            var result = await _garbageTypeSetRepository.GetAllAsync();

            return result
                .Select(GarbageTypeSetConverter.ToApi)
                .ToList();
        }

        public async Task<IList<ApiGarbageTypeSetDtoOut>> GetByGarbageCollectionPointIdAsync(int id)
        {
            var result = await _garbageTypeSetRepository.GetByGarbageCollectionPointeIdAsync(id);

            return result
                .Select(GarbageTypeSetConverter.ToApi)
                .ToList();
        }

        public async Task<IList<ApiGarbageTypeSetDtoOut>> GetByTypeOfGarbageIdAsync(int id)
        {
            var result = await _garbageTypeSetRepository.GetByTypeOfGarbageIdAsync(id);

            return result
                .Select(GarbageTypeSetConverter.ToApi)
                .ToList();
        }
    }
}