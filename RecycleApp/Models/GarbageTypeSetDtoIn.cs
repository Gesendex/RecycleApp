namespace RecycleApp.Models
{
	public partial class GarbageTypeSetDtoIn
	{
		public int IdGarbageCollectionPoint { get; set; }
		public int IdTypeOfGarbage { get; set; }

		public GarbageTypeSetDtoIn(int idGarbageCollectionPoint, int idTypeOfGarbage)
		{
			IdGarbageCollectionPoint = idGarbageCollectionPoint;
			IdTypeOfGarbage = idTypeOfGarbage;
		}

		public GarbageTypeSetDtoIn()
		{
			
		}
	}
}