namespace RecycleApp.Models
{
    public partial class AuthorizationBodyDtoIn
    {
        public string Email { get; }

        public string Password { get; }

        public AuthorizationBodyDtoIn(
            string email,
            string password
        )
        {
            Email = email;
            Password = password;
        }
    }
}