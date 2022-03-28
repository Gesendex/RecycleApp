using RecycleApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<IList<ApiCommentDtoOut>> GetAllAsync();

        public Task<IList<ApiCommentDtoOut>> GetAllByClientIdAsync(int id);

        public Task<IList<ApiCommentDtoOut>> GetAllByGarbageCollectionPointIdAsync(int id);

        public Task<ApiCommentDtoOut> GetByIdAsync(int id);

        public Task<ApiCommentDtoOut> AddAsync(ApiCommentDtoOut comment);
    }
}
