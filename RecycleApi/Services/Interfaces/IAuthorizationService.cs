using Recycle.Models.AuthorizationModels;
using RecycleApi.Models;
using System.Threading.Tasks;


namespace RecycleApi.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task Registration(ApiClientDtoOut client);

        public Task<AuthenticateResponse> Authorize(AuthorizationBody credentials);

        public Task<ApiClientDtoOut> GetById(int clientId);
    }
}