using Recycle.Models.Filters;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
	internal static class ApiGarbageCollectionPointFilterConverter
	{
		public static GarbageCollectionPointFilter ToRepository(
			ApiGarbageCollectionPointFilter source
		)
		{
			return new GarbageCollectionPointFilter(
				source.GetWithImage,
				source.PageIndex,
				source.PageSize
			);
		}
	}
}