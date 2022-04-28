using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleApi.Models
{
	public class ApiGarbageCollectionPointDtoOut
	{
		public int Id { get; }

		public string Street { get; }

		public string Building { get; }

		public ApiCompanyDtoOut Company { get; }

		public byte[] Image { get; }

		public string Description { get; }

		public IList<ApiGarbageTypeSetDtoOut> GarbageTypes { get; }

		public ApiGarbageCollectionPointDtoOut(
			int id,
			string street,
			string building,
			ApiCompanyDtoOut company,
			byte[] image,
			string description,
			IList<ApiGarbageTypeSetDtoOut> garbageTypes
		)
		{
			Id = id;
			Street = street;
			Building = building;
			Company = company;
			Image = image;
			Description = description;
			GarbageTypes = garbageTypes;
		}
	}
}