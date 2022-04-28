using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.Language;
using Recycle.Data.Repositories;
using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
	internal static class ApiGarbageCollectionPointDtoInConverter
	{
		public static GarbageCollectionPoint ToRepository(ApiGarbageCollectionPointDtoIn source)
		{
			var garbageTypes = ApiGarbageCollectionPointDtoInConverter.ToGarbageTypes(source);

			return new GarbageCollectionPoint
			{
				Id = source.Id,
				Street = source.Street,
				Building = source.Building,
				IdCompany = source.IdCompany,
				Image = source.Image,
				Description = source.Description,
				GarbageTypeSets = garbageTypes
			};
		}

		private static IList<GarbageTypeSet> ToGarbageTypes(ApiGarbageCollectionPointDtoIn source)
		{
			return source.GarbageTypeIds
				.Select(
					id => new GarbageTypeSet()
					{
						IdGarbageCollectionPoint = source.Id,
						IdTypeOfGarbage = id
					}
				)
				.ToList();
		}
	}
}