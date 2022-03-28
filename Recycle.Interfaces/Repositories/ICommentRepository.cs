using Recycle.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        public Task<Comment> AddAsync(Comment comment);
        public Task<Comment> GetByIdAsync(int id);
        public Task<IList<Comment>> GetAllAsync();
        public Task<IList<Comment>> GetAllByClientIdAsync(int id);
        public Task<IList<Comment>> GetAllByGarbageCollectionPointIdAsync(int id);
    }
}