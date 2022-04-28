using System.Collections.Generic;
using System.Threading.Tasks;
using Recycle.Models;
using RecycleApi.Models;

namespace RecycleApi.Services.Interfaces
{
	public interface IGarbageCollectionPointService
	{
		Task<IList<ApiGarbageCollectionPointDtoOut>> GetAll(
			ApiGarbageCollectionPointFilter apiGarbageCollectionPointFilter);
		Task<ApiGarbageCollectionPointDtoOut> GetById(int id);
		Task<IList<ApiGarbageCollectionPointDtoOut>> GetByTypeOfGarbageId(int id);
		Task<IList<ApiGarbageCollectionPointDtoOut>> GetByClientId(int id);
		Task<int?> CreateGarbageCollectionPoint(ApiGarbageCollectionPointDtoIn model);
		Task<int?> UpdateGarbageCollectionPoint(ApiGarbageCollectionPointDtoIn model);
	}
}