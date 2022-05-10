using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ApiGarbageTypeSetDtoOutConverter
	{
		public static GarbageTypeSetDtoIn ToService(ApiGarbageTypeSetDtoOut source)
		{
			return new GarbageTypeSetDtoIn(
				source.IdGarbageCollectionPoint,
				source.IdTypeOfGarbage
			);
		}
	}
}