using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class GarbageTypeSetDtoInConverter
	{
		public static GarbageTypeSet ToApi(
			GarbageTypeSetDtoIn source
		)
		{
			return new GarbageTypeSet()
			{
				IdGarbageCollectionPoint = source.IdGarbageCollectionPoint,
				IdTypeOfGarbage = source.IdTypeOfGarbage
			};
		}
	}
}