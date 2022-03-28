namespace RecycleApi.Models
{
    public class ApiTypeOfGarbageDtoOut
    {
        public int Id { get; }

        public string Type { get; }

        public string Description { get; }

        public byte[] MainImage { get; }

        public byte[] SubImage { get; }

        public ApiTypeOfGarbageDtoOut(
            int id,
            string type,
            string description,
            byte[] mainImage, byte[]
                subImage
        )
        {
            Id = id;
            Type = type;
            Description = description;
            MainImage = mainImage;
            SubImage = subImage;
        }
    }
}