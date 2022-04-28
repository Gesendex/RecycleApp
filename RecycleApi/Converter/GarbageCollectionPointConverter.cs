using System.Linq;
using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
	internal static class GarbageCollectionPointConverter
	{
		public static ApiGarbageCollectionPointDtoOut ToApi(GarbageCollectionPoint source)
		{
			var garbageTypeSets = source.GarbageTypeSets
				.Select(GarbageTypeSetConverter.ToApi)
				.ToList();

			var company = CompanyConverter.ToApi(source.IdCompanyNavigation);

			return new ApiGarbageCollectionPointDtoOut(
				id: source.Id,
				street: source.Street,
				building: source.Building,
				company: company,
				image: source.Image,
				description: source.Description,
				garbageTypes: garbageTypeSets
			);
		}
	}
}