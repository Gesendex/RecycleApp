namespace RecycleApi.Models
{
    public class ApiClientDtoOut
    {
        public int Id { get; }

        public string Name { get; }

        public string Middlename { get; }

        public string Surname { get; }

        public string Email { get; }

        public int IdRole { get; }

        public ApiClientDtoOut(
            int id,
            string name,
            string middlename,
            string surname,
            string email,
            int idRole)
        {
            Id = id;
            Name = name;
            Middlename = middlename;
            Surname = surname;
            Email = email;
            IdRole = idRole;
        }
    }
}