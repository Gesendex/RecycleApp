using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
    internal static class TypeOfGarbageConverter
    {
        public static ApiTypeOfGarbageDtoOut ToApi(TypeOfGarbage source)
        {
            return new ApiTypeOfGarbageDtoOut(
                id: source.Id,
                type: source.Type,
                description: source.Description,
                mainImage: source.TypeImage?.MainImage,
                subImage: source.TypeImage?.SubImage
            );
        }

        public static ApiTypeOfGarbageDtoOut ToApiWithoutImage(TypeOfGarbage source)
        {
            return new ApiTypeOfGarbageDtoOut(
                id: source.Id,
                type: source.Type,
                description: source.Description,
                mainImage: null,
                subImage: null
            );
        }
    }
}