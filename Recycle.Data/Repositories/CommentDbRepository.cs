using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Repositories;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Data.Repositories
{
    public class CommentDbRepository : ICommentRepository
    {
        private RecycleContext db;
        public CommentDbRepository(RecycleContext db)
        {
            this.db = db;
        }
        public async Task<Comment> AddAsync(Comment comment)
        {
            try
            {
                var createdComment = await db.Comments.AddAsync(comment);
                return createdComment.Entity;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка во время добавления комментария");
            }
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            try
            {
                return await db.Comments.ToListAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ошибка во время получения комментариев");
            }

        }

        public async Task<IEnumerable<Comment>> GetAllByClientIdAsync(int id)
        {
            try
            {
                return await db.Comments.Where(p => p.IdClient == id).ToListAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ошибка во время получения комментариев");
            }
        }

        public async Task<IEnumerable<Comment>> GetAllByGarbageCollectionPointIdAsync(int id)
        {
            try
            {
                return await db.Comments.Where(p => p.IdGarbageCollectionPoint == id).ToListAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ошибка во время получения комментариев");
            }
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            try
            {
                return await db.Comments.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception)
            {

                throw new Exception("Ошибка во время получения комментария");
            }
        }
    }
}
