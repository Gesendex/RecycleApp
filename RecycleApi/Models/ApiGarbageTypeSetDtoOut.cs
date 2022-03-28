namespace RecycleApi.Models
{
    public class ApiGarbageTypeSetDtoOut
    {
        public int IdGarbageCollectionPoint { get;  }
        public int IdTypeOfGarbage { get;  }

        public ApiGarbageTypeSetDtoOut(int idGarbageCollectionPoint, int idTypeOfGarbage)
        {
            IdGarbageCollectionPoint = idGarbageCollectionPoint;
            IdTypeOfGarbage = idTypeOfGarbage;
        }
    }
}
