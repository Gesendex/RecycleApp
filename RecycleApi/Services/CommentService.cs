using Recycle.Interfaces.Repositories;
using Recycle.Models;
using RecycleApi.Converter;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    internal class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITimeProviderService _timeProvider;

        public CommentService(ICommentRepository commentRepository, ITimeProviderService timeProvider)
        {
            _commentRepository = commentRepository;
            _timeProvider = timeProvider;
        }

        public async Task<ApiCommentDtoOut> AddAsync(ApiCommentDtoOut model)
        {
            if (model == null)
                throw new ArgumentNullException("Отсутствует комментарий для записи");

            if (string.IsNullOrWhiteSpace(model.Text))
                throw new ArgumentException("Комментарий не должен быть пустым");

            //TODO: Когда будет готов сервис для клиентов и точек сбора мусора, надо сделать проверку на то, что комментарий ссылается на существующего клиента и существующую точку сбора мусора.

            if (false) //Проверка клиента
                throw new ArgumentException("Пользователь не найден");
            if (false) //Проверка точки сбора мусора
                throw new ArgumentException("Точка сбора мусора не найдена");


            var comment = CommentConverter.ToRepository(model, _timeProvider);

            var res = await _commentRepository.AddAsync(comment);

            return CommentConverter.ToApi(res);
        }

        public async Task<IList<ApiCommentDtoOut>> GetAllAsync()
        {
            var res = await _commentRepository.GetAllAsync();

            return res
                .Select(CommentConverter.ToApi)
                .ToList();
        }

        public async Task<IList<ApiCommentDtoOut>> GetAllByClientIdAsync(int id)
        {
            var res = await _commentRepository.GetAllByClientIdAsync(id);

            return res
                .Select(CommentConverter.ToApi)
                .ToList();
        }

        public async Task<IList<ApiCommentDtoOut>> GetAllByGarbageCollectionPointIdAsync(int id)
        {
            var res = await _commentRepository.GetAllByGarbageCollectionPointIdAsync(id);

            return res
                .Select(CommentConverter.ToApi)
                .ToList();
        }

        public async Task<ApiCommentDtoOut> GetByIdAsync(int id)
        {
            var res = await _commentRepository.GetByIdAsync(id);

            return CommentConverter.ToApi(res);
        }
    }
}