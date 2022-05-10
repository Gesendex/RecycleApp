using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Models
{
	public partial class GarbageCollectionPointDtoIn
	{
		public int Id { get; set; }
		public string Building { get; set; }
		public string Street { get; set; }
		public string Description { get; set; }
		public byte[] Image { get; set; }
		public int IdCompany { get; set; }
		public IList<GarbageTypeSetDtoIn> GarbageTypeSets { get; set; }
		public CompanyDtoIn Company { get; set; }

		public GarbageCollectionPointDtoIn()
		{
			
		}
		public GarbageCollectionPointDtoIn(
			int id,
			string building,
			string street,
			string description,
			byte[] image,
			int idCompany,
			IList<GarbageTypeSetDtoIn> garbageTypeSets,
			CompanyDtoIn company
		)
		{
			Id = id;
			Building = building;
			Street = street;
			Description = description;
			Image = image;
			IdCompany = idCompany;
			GarbageTypeSets = garbageTypeSets;
			Company = company;
		}
	}
}