namespace RecycleApi.Models
{
    internal class ApiGarbageTypeSetDtoOut
    {
        public int Id { get; }
        public string Type { get; }
        public string Description { get; }

        public ApiGarbageTypeSetDtoOut(
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
