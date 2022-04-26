using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ApiCommentDtoOutConverter
	{
		public static CommentDtoIn ToCommentDtoIn(ApiCommentDtoOut source)
		{
			return new CommentDtoIn(
				source.Id,
				source.IdClient,
				source.IdGarbageCollectionPoint,
				source.Text,
				source.DateOfCreation
			);
		}
	}
}