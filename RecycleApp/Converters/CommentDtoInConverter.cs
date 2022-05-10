using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class CommentDtoInConverter
	{
		public static ApiCommentDtoOut ToApi(CommentDtoIn source)
		{
			return new ApiCommentDtoOut()
			{
				Id = source.Id,
				DateOfCreation = source.DateOfCreation,
				IdClient = source.IdClient,
				IdGarbageCollectionPoint = source.IdGarbageCollectionPoint,
				Text = source.Text
			};
		}
	}
}