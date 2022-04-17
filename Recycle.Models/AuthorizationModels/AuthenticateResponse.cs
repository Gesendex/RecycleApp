namespace Recycle.Models.AuthorizationModels
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }


        public AuthenticateResponse(Client user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Middlename = user.Middlename;
            Surname = user.Surname;
            Username = user.Email;
            Token = token;
            RoleId = user.IdRole;
        }
    }
}
