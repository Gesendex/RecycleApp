using Recycle.Models;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;

namespace RecycleApi.Converter
{
    internal static class CommentConverter
    {
        public static ApiCommentDtoOut ToApi(Comment source)
        {
            return new ApiCommentDtoOut(
                id: source.Id,
                text: source.Text,
                idGarbageCollectionPoint: source.IdGarbageCollectionPoint,
                idClient: source.IdClient,
                dateOfCreation: source.DateOfCreation
            );
        }

        public static Comment ToRepository(ApiCommentDtoOut source, ITimeProviderService service)
        {
            return new Comment
            {
                Text = source.Text,
                IdGarbageCollectionPoint = source.IdGarbageCollectionPoint,
                IdClient = source.IdClient,
                DateOfCreation = service.CurrentDateTime
            };
        }
    }
}
