using RecycleApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Services.Interfaces
{
    public interface ITypeOfGarbageService
    {
        public Task<IList<ApiTypeOfGarbageDtoOut>> GetAllAsync();

        public Task<IList<ApiTypeOfGarbageDtoOut>> GetAllWithImageAsync();

        public Task<ApiTypeOfGarbageDtoOut> GetByIdAsync(int id);

        public Task<ApiTypeOfGarbageDtoOut> GetByIdWithImageAsync(int id);

    }
}
