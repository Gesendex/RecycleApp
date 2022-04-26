using System.Linq;
using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class GarbageCollectionPointDtoInConverter
	{
		public static GarbageCollectionPoint ToApi(
			GarbageCollectionPointDtoIn source
		)
		{
			var garbageTypeSet = source.GarbageTypeSets
				.Select(GarbageTypeSetDtoInConverter.ToApi)
				.ToList();

			return new GarbageCollectionPoint
			{
				Id = source.Id,
				Street = source.Street,
				Building = source.Building,
				IdCompany = source.IdCompany,
				Image = source.Image,
				Description = source.Description,
				IdCompanyNavigation = null,
				GarbageTypeSets = garbageTypeSet
			};
		}
	}
}