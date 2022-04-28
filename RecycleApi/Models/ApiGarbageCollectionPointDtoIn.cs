using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecycleApi.Models
{
	public class ApiGarbageCollectionPointDtoIn
	{
		public int Id { get; set; }

		[Required]
		public string Street { get; set; }

		[Required]
		public string Building { get; set; }
		
		public int IdCompany { get; set; }

		public byte[] Image { get; set; }

		public string Description { get; set; }

		public IList<int> GarbageTypeIds { get; set; }

		public ApiGarbageCollectionPointDtoIn(
			int id,
			string street,
			string building,
			int idCompany,
			byte[] image,
			string description,
			IList<int> garbageTypeIds)
		{
			Id = id;
			Street = street;
			Building = building;
			IdCompany = idCompany;
			Image = image;
			Description = description;
			GarbageTypeIds = garbageTypeIds;
		}
	}
}