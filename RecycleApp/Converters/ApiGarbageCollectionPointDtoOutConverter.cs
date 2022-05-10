using System.Linq;
using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ApiGarbageCollectionPointDtoOutConverter
	{
		public static GarbageCollectionPointDtoIn ToService(ApiGarbageCollectionPointDtoOut source)
		{
			var garbageTypeSets = source.GarbageTypes
				.Select(ApiGarbageTypeSetDtoOutConverter.ToService)
				.ToList();

			var company = ApiCompanyDtoOutConverter.ToCompanyDtoIn(source.Company);

			return new GarbageCollectionPointDtoIn(
				id: source.Id,
				building: source.Building,
				street: source.Street,
				description: source.Description,
				image: source.Image,
				idCompany: source.Company.Id,
				garbageTypeSets: garbageTypeSets,
				company: company
			);
		}
	}
}