using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
    internal static class GarbageTypeSetConverter
    {
        public static ApiGarbageTypeSetDtoOut ToApi(GarbageTypeSet source)
        {
            return new ApiGarbageTypeSetDtoOut(
                idGarbageCollectionPoint: source.IdGarbageCollectionPoint,
                idTypeOfGarbage: source.IdTypeOfGarbage
            );
        }
    }
}