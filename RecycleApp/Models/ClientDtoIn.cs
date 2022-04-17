namespace RecycleApp.Models
{
	public class ClientDtoIn
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Middlename { get; set; }

		public string Surname { get; set; }

		public string Username { get; set; }

		public string Token { get; set; }

		public int RoleId { get; set; }

		public string Email { get; set; }

		public int IdRole { get; set; }

		public string Password { get; set; }

		public ClientDtoIn(int id, string name, string middlename, string surname, string username, string token,
			int roleId)
		{
			Id = id;
			Name = name;
			Middlename = middlename;
			Surname = surname;
			Username = username;
			Token = token;
			RoleId = roleId;
		}

		public ClientDtoIn()
		{
			
		}
	}
}