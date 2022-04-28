using System.Collections.Generic;
using System.Threading.Tasks;
using Recycle.Models;
using Recycle.Models.Filters;

namespace Recycle.Interfaces.Repositories
{
	public interface IGarbageCollectionPointRepository
	{
		Task<IList<GarbageCollectionPoint>> GetAll(GarbageCollectionPointFilter filter);
		Task<IList<GarbageCollectionPoint>> GetByTypeOfGarbageId(int id);
		Task<IList<GarbageCollectionPoint>> GetByClientId(int id);
		Task<GarbageCollectionPoint> GetById(int id);
		Task<int?> CreateGarbageCollectionPoint(GarbageCollectionPoint point);
		Task<int?> UpdateGarbageCollectionPoint(GarbageCollectionPoint point);
		Task DeleteGarbageCollectionPoint(int id);
	}
}