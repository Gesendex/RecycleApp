namespace RecycleApi.Models
{
	public class ApiClientDtoIn
	{
		public int Id { get; }

		public string Name { get; }

		public string Middlename { get; }

		public string Surname { get; }

		public string Email { get; }

		public string Password { get; }

		public int IdRole { get; }

		public ApiClientDtoIn(
			int id,
			string name,
			string middlename,
			string surname,
			string email,
			string password,
			int idRole
		)
		{
			Id = id;
			Name = name;
			Middlename = middlename;
			Surname = surname;
			Email = email;
			Password = password;
			IdRole = idRole;
		}
	}
}