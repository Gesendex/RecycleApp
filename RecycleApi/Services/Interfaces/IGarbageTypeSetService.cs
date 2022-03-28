using RecycleApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Services.Interfaces
{
    public interface IGarbageTypeSetService
    {
        Task<IList<ApiGarbageTypeSetDtoOut>> GetAllAsync();

        Task<IList<ApiGarbageTypeSetDtoOut>> GetByTypeOfGarbageIdAsync(int id);

        Task<IList<ApiGarbageTypeSetDtoOut>> GetByGarbageCollectionPointIdAsync(int id);
    }
}
