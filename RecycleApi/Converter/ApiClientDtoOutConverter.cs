using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Converter
{
	internal static class ApiClientDtoOutConverter
	{
		public static Client ToRepository(ApiClientDtoIn client)
		{
			return new Client
			{
				Name = client.Name,
				Middlename = client.Middlename,
				Surname = client.Surname,
				Email = client.Email,
				Password = client.Password,
				IdRole = client.IdRole,
			};
		}
	}
}