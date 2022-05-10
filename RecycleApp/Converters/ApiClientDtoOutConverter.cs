using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ApiClientDtoOutConverter
	{
		public static ClientDtoIn ToService(ApiClientDtoOut sourceClient)
		{
			return new ClientDtoIn
			{
				Id = sourceClient.Id,
				Name = sourceClient.Name,
				Middlename = sourceClient.Middlename,
				Surname = sourceClient.Surname,
				Email = sourceClient.Email,
				IdRole = sourceClient.IdRole
			};
		}
	}
}