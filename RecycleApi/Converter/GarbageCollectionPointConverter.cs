using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
    internal static class GarbageCollectionPointConverter
    {
        public static ApiGarbageCollectionPointDtoOut ToApi(GarbageCollectionPoint source)
        {
            return new ApiGarbageCollectionPointDtoOut(
                id: source.Id,
                street: source.Street,
                building: source.Building,
                idCompany: source.IdCompany,
                image: source.Image,
                description: source.Description
            );
        }
    }
}