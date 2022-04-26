namespace RecycleApp.Models
{
	public class CompanyDtoIn
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Owner { get; set; }
		public string Description { get; set; }
		public int? ClientId { get; set; }
		public byte[] Image { get; set; }

		public CompanyDtoIn(
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

		public CompanyDtoIn(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}