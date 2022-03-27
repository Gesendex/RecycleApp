using Recycle.Models;
using RecycleApi.Models;

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
    }
}
