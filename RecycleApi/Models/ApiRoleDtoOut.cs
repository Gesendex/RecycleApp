namespace RecycleApi.Models
{
    public class ApiRoleDtoOut
    {
        public int Id { get; }

        public string RoleName { get; }

        public ApiRoleDtoOut(
            int id,
            string roleName)
        {
            Id = id;
            RoleName = roleName;
        }
    }
}
