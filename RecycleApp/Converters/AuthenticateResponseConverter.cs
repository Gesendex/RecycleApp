using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal class AuthenticateResponseConverter
	{
		public static ClientDtoIn ToClientDtoIn(AuthenticateResponse source)
		{
			return new ClientDtoIn(
				id: source.Id,
				name: source.Name,
				middlename: source.Middlename,
				surname: source.Surname,
				token: source.Token,
				idRole: source.RoleId
			);
		}
	}
}