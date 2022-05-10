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
                var res = await db.Comments
                    .AddAsync(comment);
                await db.SaveChangesAsync();

                return res.Entity;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка во время добавления комментария");
            }
        }

        public async Task<IList<Comment>> GetAllAsync()
        {
            try
            {
                var res = await db.Comments
                    .OrderByDescending(item => item.DateOfCreation)
                    .ToListAsync();

                return res;
            }
            catch (Exception)
            {

                throw new Exception("Ошибка во время получения комментариев");
            }

        }

        public async Task<IList<Comment>> GetAllByClientIdAsync(int id)
        {
            try
            {
                var res = await db.Comments
                    .Where(item => item.IdClient == id)
                    .OrderByDescending(item => item.DateOfCreation)
                    .ToListAsync();

                return res;
            }
            catch (Exception)
            {

                throw new Exception("Ошибка во время получения комментариев");
            }
        }

        public async Task<IList<Comment>> GetAllByGarbageCollectionPointIdAsync(int id)
        {
            try
            {
                var res = await db.Comments
                    .Where(p => p.IdGarbageCollectionPoint == id)
                    .OrderByDescending(item => item.DateOfCreation)
                    .ToListAsync();

                return res;
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
                var res = await db.Comments
                    .FirstOrDefaultAsync(p => p.Id == id);

                return res;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка во время получения комментария");
            }
        }
    }
}
