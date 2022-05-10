using Recycle.Models.AuthorizationModels;
using RecycleApi.Models;
using System.Threading.Tasks;


namespace RecycleApi.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<ApiClientDtoOut> Registration(ApiClientDtoIn client);

        public Task<AuthenticateResponse> Authorize(AuthorizationBody credentials);

        public Task<ApiClientDtoOut> GetById(int clientId);
    }
}