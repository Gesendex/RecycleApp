using RecycleApp.Models;
using RecycleApp.RecycleApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleApp.Services
{
	internal class RecycleService : IRecycleService
	{
		private readonly IRecycleClient _recycleClient;

		public RecycleService(IRecycleClient recycleClient)
		{
			_recycleClient = recycleClient;
		}


		public async Task<ClientDtoIn> AuthorizeAsync(AuthorizationBodyDtoIn credentials)
		{

			try
			{
				var res = await _recycleClient.ApiUserAuthorizationAsync(
					new AuthorizationBody
					{
						Email = credentials.Email,
						Password = credentials.Password
					}
				);

				return new ClientDtoIn(
					id: res.Id,
					name: res.Name,
					middlename: res.Middlename,
					surname: res.Surname,
					username: res.Username,
					token: res.Token,
					roleId: res.RoleId
				);
			}
			catch (Exception e)
			{
				return null;
			}
		}
	}
}