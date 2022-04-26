using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleApp.Models;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Converters
{
	internal static class ApiCompanyDtoOutConverter
	{
		public static CompanyDtoIn ToCompanyDtoIn(ApiCompanyDtoOut source)
		{
			return new CompanyDtoIn(
				id: source.Id,
				name: source.Name,
				owner: source.Owner,
				description: source.Description,
				clientId: source.ClientId,
				image: source.Image
			);
		}
	}
}