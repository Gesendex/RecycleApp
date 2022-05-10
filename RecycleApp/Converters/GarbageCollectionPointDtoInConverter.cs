using System.Linq;
using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class GarbageCollectionPointDtoInConverter
	{
		public static ApiGarbageCollectionPointDtoIn ToApi(
			GarbageCollectionPointDtoIn source
		)
		{
			var garbageTypeSet = source.GarbageTypeSets
				.Select(item => item.IdTypeOfGarbage)
				.ToList();

			return new ApiGarbageCollectionPointDtoIn
			{
				Id = source.Id,
				Street = source.Street,
				Building = source.Building,
				IdCompany = source.IdCompany,
				Image = source.Image,
				Description = source.Description,
				GarbageTypeIds = garbageTypeSet,
			};
		}
	}
}