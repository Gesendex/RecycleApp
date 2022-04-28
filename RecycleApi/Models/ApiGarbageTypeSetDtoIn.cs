using System.ComponentModel.DataAnnotations;

namespace RecycleApi.Models
{
	public class ApiGarbageTypeSetDtoIn
	{
		[Required]
		public int IdGarbageCollectionPoint { get; }

		[Required]
		public int IdTypeOfGarbage { get; }

		public ApiGarbageTypeSetDtoIn(int idGarbageCollectionPoint, int idTypeOfGarbage)
		{
			IdGarbageCollectionPoint = idGarbageCollectionPoint;
			IdTypeOfGarbage = idTypeOfGarbage;
		}
    }
}