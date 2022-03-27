namespace RecycleApi.Models
{
    internal class ApiTypeOfGarbageDtoOut
    {
        public int Id { get; }

        public string Type { get; }

        public string Description { get; }

        public ApiTypeOfGarbageDtoOut(
            int id,
            string type,
            string description)
        {
            Id = id;
            Type = type;
            Description = description;
        }
    }
}
