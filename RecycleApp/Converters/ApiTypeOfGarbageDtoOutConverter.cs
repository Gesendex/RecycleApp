using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ApiTypeOfGarbageDtoOutConverter
	{
		public static TypeOfGarbageDtoIn ToTypeOfGarbageDtoIn(ApiTypeOfGarbageDtoOut source)
		{
			var typeImage = new TypeImageDtoIn(
				id: source.Id,
				mainImage: source.MainImage,
				subImage: source.SubImage
			);

			return new TypeOfGarbageDtoIn(
				id: source.Id,
				type: source.Type,
				typeImage: typeImage,
				description: source.Description
			);
		}
	}
}