using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
    internal static class ClientConverter
    {
        public static ApiClientDtoOut ToApi(Client source)
        {
            return new ApiClientDtoOut(
                id: source.Id,
                name: source.Name,
                middlename: source.Middlename,
                surname: source.Surname,
                email: source.Email,
                idRole: source.IdRole
            );
        }
    }
}