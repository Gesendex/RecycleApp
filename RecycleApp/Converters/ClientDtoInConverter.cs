using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ClientDtoInConverter
	{
		public static ApiClientDtoIn ToApi(ClientDtoIn client)
		{
			return new ApiClientDtoIn
			{
				Name = client.Name,
				Middlename = client.Middlename,
				Surname = client.Surname,
				Email = client.Email,
				Password = client.Password,
				IdRole = client.IdRole
			};
		}
	}
}