using Recycle.Models;
using Recycle.Models.AuthorizationModels;
using System.Threading.Tasks;


namespace Recycle.Interfaces.Services
{
    public interface IAuthorizationService
    {
        public Task Registration(Client client);
        public Task<AuthenticateResponse> Authorize(AuthorizationBody credentials);
        public Task<Client> GetById(int clientId);
    }
}
