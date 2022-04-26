using RecycleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleApp.Services
{
    public interface IRecycleService
    {
        Task<ClientDtoIn> AuthorizeAsync(AuthorizationBodyDtoIn credentials);
        Task<IList<GarbageCollectionPointDtoIn>> GetGarbageCollectionPointsAsync();
        Task<IList<CompanyDtoIn>> GetCompaniesAsync();
        Task<IList<TypeOfGarbageDtoIn>> GetTypeOfGarbageWithImageAsync();
        Task<IList<CommentDtoIn>> GetAllCommentsByGcpId(int currentGcpId);
        Task<bool> PutComment(CommentDtoIn com);
        Task<IList<GarbageCollectionPointDtoIn>> GetGarbageCollectionPointsByClientIdAsync(int currentClientId);
        Task<bool> DeleteGarbageCollectionPoint(int id);
        Task<IList<TypeOfGarbageDtoIn>> GetTypeOfGarbageAsync();
        Task<bool> UpdateGarbageCollectionPoint(GarbageCollectionPointDtoIn garbageCollectionPoint);
        Task<IList<TypeOfGarbageDtoIn>> GetTypeOfGarbageByGarbageCollectionPointIdAsync(int id);
    }
}
