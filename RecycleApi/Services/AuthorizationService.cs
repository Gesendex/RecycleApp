using Recycle.Interfaces.Repositories;
using Recycle.Interfaces.Services;
using Recycle.Models;
using Recycle.Models.AuthorizationModels;
using RecycleApi.Helpers;
using System;
using System.Threading.Tasks;

namespace RecycleApi.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IClientRepository _clientRepository;
        private readonly AuthorizationHelper _authorizationHelper;

        public AuthorizationService(IClientRepository clientRepository, AuthorizationHelper authorizationHelper)
        {
            _clientRepository = clientRepository;
            _authorizationHelper = authorizationHelper;
        }

        public async Task<AuthenticateResponse> Authorize(AuthorizationBody credentials)
        {
            var user = await _clientRepository.GetClientAsync(credentials);

            // return null if user not found
            if (user == null) 
                return null;

            // authentication successful so generate jwt token
            var token = _authorizationHelper.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task Registration(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetById(int clientId)
        {
            var res = await _clientRepository.GetClientAsync(clientId);

            return res;
        }
    }
}
