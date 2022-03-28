namespace RecycleApi.Models
{
    public class ApiCompanyDtoOut
    {
        public int Id { get; }

        public string Name { get; }

        public string Owner { get; }

        public string Description { get; }

        public int? ClientId { get; }

        public byte[] Image { get; }

        public ApiCompanyDtoOut(
            int id,
            string name,
            string owner,
            string description,
            int? clientId,
            byte[] image
        )
        {
            Id = id;
            Name = name;
            Owner = owner;
            Description = description;
            ClientId = clientId;
            Image = image;
        }
    }
}