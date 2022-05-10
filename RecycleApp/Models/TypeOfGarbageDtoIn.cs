namespace RecycleApp.Models
{
	public partial class TypeOfGarbageDtoIn
    {
	    public int Id { get; set; }
		public string Type { get; set; }
	    public TypeImageDtoIn TypeImage { get; set; }
	    public string Description { get; set; }

	    public TypeOfGarbageDtoIn(int id, string type, TypeImageDtoIn typeImage, string description)
	    {
		    Id = id;
		    Type = type;
		    TypeImage = typeImage;
		    Description = description;
	    }

		public TypeOfGarbageDtoIn(int id, string type)
		{
			Id = id;
			Type = type;
		}
	}
}
