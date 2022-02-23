using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Interfaces.Services
{
    public interface ICommentService
    {
        public Task<IEnumerable<Comment>> GetAllAsync();
        public Task<IEnumerable<Comment>> GetAllByClientIdAsync(int id);
        public Task<IEnumerable<Comment>> GetAllByGarbageCollectionPointIdAsync(int id);
        public Task<Comment> GetByIdAsync(int id);
        public Task<Comment> AddAsync(Comment comment);

    }
}
