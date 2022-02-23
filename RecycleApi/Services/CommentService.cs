using Recycle.Interfaces;
using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository commentRepository;
        private ITimeProviderService timeProvider;
        public CommentService(ICommentRepository commentRepository, ITimeProviderService timeProvider)
        {
            this.commentRepository = commentRepository;
            this.timeProvider = timeProvider;
        }
        public async Task<Comment> AddAsync(Comment comment)
        {
            if (comment == null)// Возможно стоит изменить тип исключения на ArgumenNullExeption, но тогда и в контроллере предется отдельно ловить исключение, хотя и обрабатываться оно будет также
                throw new ArgumentException("Отсутствует комментарий для записи");
            if (string.IsNullOrWhiteSpace(comment.Text))
                throw new ArgumentException("Комментарий не должен быть пустым");
            //TODO: Когда будет готов сервис для клиентов и точек сбора мусора, надо сделать проверку на то, что комментарий ссылается на существующего клиента и существующую точку сбора мусора.
            if (false)//Проверка клиента
                throw new ArgumentException("Пользователь не найден");
            if (false)//Проверка точки сбора мусора
                throw new ArgumentException("Точка сбора мусора не найдена");

            comment.DateOfCreation = timeProvider.CurrentDateTime;
            comment.Id = 0;
            return await commentRepository.AddAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var comments = await commentRepository.GetAllAsync();
            return comments.OrderByDescending(p => p.DateOfCreation);
        }

        public async Task<IEnumerable<Comment>> GetAllByClientIdAsync(int id)
        {
            var comments = await commentRepository.GetAllByClientIdAsync(id);
            return comments.OrderByDescending(p => p.DateOfCreation);
        }

        public async Task<IEnumerable<Comment>> GetAllByGarbageCollectionPointIdAsync(int id)
        {
            var comments = await commentRepository.GetAllByGarbageCollectionPointIdAsync(id);
            return comments.OrderByDescending(p => p.DateOfCreation);
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await commentRepository.GetByIdAsync(id);
        }
    }
}
