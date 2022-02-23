using Recycle.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Task<Comment> AddAsync(Comment comment);
        public Task<Comment> GetByIdAsync(int id);
        public Task<IEnumerable<Comment>> GetAllAsync();
        public Task<IEnumerable<Comment>> GetAllByClientIdAsync(int id);
        public Task<IEnumerable<Comment>> GetAllByGarbageCollectionPointIdAsync(int id);
    }
}