using Recycle.Interfaces.Repositories;
using RecycleApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleApi.Converter;
using RecycleApi.Models;

namespace RecycleApi.Services
{
    public class TypeOfGarbageService : ITypeOfGarbageService
    {
        private readonly ITypeOfGarbageRepository _typeOfGarbageRepository;

        public TypeOfGarbageService(ITypeOfGarbageRepository typeOfGarbageRepository)
        {
            _typeOfGarbageRepository = typeOfGarbageRepository;
        }

        public async Task<IList<ApiTypeOfGarbageDtoOut>> GetAllAsync()
        {
            var res = await _typeOfGarbageRepository.GetAllAsync();

            return res
                .Select(TypeOfGarbageConverter.ToApi)
                .ToList();
        }

        public async Task<IList<ApiTypeOfGarbageDtoOut>> GetAllWithImageAsync()
        {
            var res = await _typeOfGarbageRepository.GetAllWithImageAsync();

            return res
                .Select(TypeOfGarbageConverter.ToApi)
                .ToList();
        }

        public async Task<ApiTypeOfGarbageDtoOut> GetByIdAsync(int id)
        {
            var res = await _typeOfGarbageRepository.GetByIdAsync(id);

            return TypeOfGarbageConverter.ToApi(res);
        }

        public async Task<ApiTypeOfGarbageDtoOut> GetByIdWithImageAsync(int id)
        {
            var res = await _typeOfGarbageRepository.GetByIdWithImageAsync(id);

            return TypeOfGarbageConverter.ToApi(res);
        }
    }
}