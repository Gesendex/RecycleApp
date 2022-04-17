using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleApp.RecycleApiService;

namespace RecycleApp.Models
{
    public class GarbageCollectionPointDtoIn
    {
	    public string Building { get; set; }
	    public string Street { get; set; }
	    public string Description { get; set; }
	    public byte[] Image { get; set; }
	    public int IdCompany { get; set; }
	    public int Id { get; set; }
	    public IList<GarbageTypeSetDtoIn> GarbageTypeSets { get; set; }
	    public CompanyDtoIn Company { get; set; }
	    public string FullAddress { get; set; }
    }
}
