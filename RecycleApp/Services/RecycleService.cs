using RecycleApp.Models;
using RecycleApp.RecycleApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleApp.Converters;

namespace RecycleApp.Services
{
	internal class RecycleService : IRecycleService
	{
		private readonly IRecycleClient _recycleClient;

		public RecycleService(IRecycleClient recycleClient)
		{
			_recycleClient = recycleClient;
		}


		public async Task<ClientDtoIn> AuthorizeAsync(AuthorizationBodyDtoIn credentials)
		{
			try
			{
				var res = await _recycleClient.ApiUserAuthorizationAsync(
					new AuthorizationBody
					{
						Email = credentials.Email,
						Password = credentials.Password
					}
				);

				return AuthenticateResponseConverter.ToClientDtoIn(res);
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public async Task<IList<GarbageCollectionPointDtoIn>> GetGarbageCollectionPointsAsync()
		{
			return new List<GarbageCollectionPointDtoIn>();
		}

		public async Task<IList<CompanyDtoIn>> GetCompaniesAsync()
		{
			try
			{
				var res = await _recycleClient.ApiCompanyGetallAsync();
				return res
					.Select(ApiCompanyDtoOutConverter.ToCompanyDtoIn)
					.ToList();
			}
			catch (Exception e)
			{
				return new List<CompanyDtoIn>();
			}
		}

		public async Task<IList<TypeOfGarbageDtoIn>> GetTypeOfGarbageWithImageAsync()
		{
			try
			{
				var res = await _recycleClient.ApiTypeofgarbageGetallwithimageAsync();
				return res
					.Select(ApiTypeOfGarbageDtoOutConverter.ToTypeOfGarbageDtoIn)
					.ToList();
			}
			catch (Exception e)
			{
				return new List<TypeOfGarbageDtoIn>();
			}
		}

		public async Task<IList<CommentDtoIn>> GetAllCommentsByGcpId(int currentGcpId)
		{
			var res = await _recycleClient.ApiCommentGetallbygcpidAsync(currentGcpId);
			return res
				.Select(ApiCommentDtoOutConverter.ToCommentDtoIn)
				.ToList();
		}

		public async Task<bool> PutComment(CommentDtoIn comment)
		{
			var apiComment = CommentDtoInConverter.ToApi(comment);

			try
			{
				await _recycleClient.ApiCommentWritecommentAsync(apiComment);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public async Task<IList<GarbageCollectionPointDtoIn>> GetGarbageCollectionPointsByClientIdAsync(
			int currentClientId
		)
		{
			return new List<GarbageCollectionPointDtoIn>();
		}

		public async Task<bool> DeleteGarbageCollectionPoint(int id)
		{
			try
			{
				await DeleteGarbageCollectionPoint(id);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public async Task<IList<TypeOfGarbageDtoIn>> GetTypeOfGarbageAsync()
		{
			try
			{
				var res = await _recycleClient.ApiTypeofgarbageGetallAsync();
				return res
					.Select(ApiTypeOfGarbageDtoOutConverter.ToTypeOfGarbageDtoIn)
					.ToList();
			}
			catch (ApiException e)
			{
				return new List<TypeOfGarbageDtoIn>();
			}
		}

		public async Task<bool> UpdateGarbageCollectionPoint(GarbageCollectionPointDtoIn garbageCollectionPoint)
		{
			try
			{
				var data = GarbageCollectionPointDtoInConverter.ToApi(garbageCollectionPoint);
				await _recycleClient.ApiGarbagecollectionpointUpdateAsync(data);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public async Task<IList<TypeOfGarbageDtoIn>> GetTypeOfGarbageByGarbageCollectionPointIdAsync(int id)
		{
			try
			{
				var res = await _recycleClient.ApiTypeofgarbageGetallAsync();
				return res
					.Select(ApiTypeOfGarbageDtoOutConverter.ToTypeOfGarbageDtoIn)
					.ToList();
			}
			catch (ApiException e)
			{
				return new List<TypeOfGarbageDtoIn>();
			}
		}
	}
}