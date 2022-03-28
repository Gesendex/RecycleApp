using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
    internal static class RoleConverter
    {
        public static ApiRoleDtoOut ToApi(Role source)
        {
            return new ApiRoleDtoOut(
                id: source.Id,
                roleName: source.RoleName
            );
        }
    }
}