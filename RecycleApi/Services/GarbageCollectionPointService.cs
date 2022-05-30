using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Recycle.Interfaces.Repositories;
using Recycle.Models;
using RecycleApi.Converter;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;

namespace RecycleApi.Services
{
	public class GarbageCollectionPointService : IGarbageCollectionPointService
	{
		private readonly IGarbageCollectionPointRepository _garbageCollectionPointRepository;

		public GarbageCollectionPointService(
			IGarbageCollectionPointRepository garbageCollectionPointRepository
		)
		{
			_garbageCollectionPointRepository = garbageCollectionPointRepository;
		}

		public async Task<IList<ApiGarbageCollectionPointDtoOut>> GetAll(
			ApiGarbageCollectionPointFilter apiGarbageCollectionPointFilter)
		{
			var filter = ApiGarbageCollectionPointFilterConverter.ToRepository(apiGarbageCollectionPointFilter);

			var res = await _garbageCollectionPointRepository.GetAll(filter);

			return res
				.Select(GarbageCollectionPointConverter.ToApi)
				.ToList();
		}

		public async Task<ApiGarbageCollectionPointDtoOut> GetById(int id)
		{
			var res = await _garbageCollectionPointRepository.GetById(id);

			return GarbageCollectionPointConverter.ToApi(res);
		}

		public async Task<IList<ApiGarbageCollectionPointDtoOut>> GetByTypeOfGarbageId(int id)
		{
			var res = await _garbageCollectionPointRepository.GetByTypeOfGarbageId(id);

			return res
				.Select(GarbageCollectionPointConverter.ToApi)
				.ToList();
		}

		public async Task<IList<ApiGarbageCollectionPointDtoOut>> GetByClientId(int id)
		{
			var res = await _garbageCollectionPointRepository.GetByClientId(id);

			return res
				.Select(GarbageCollectionPointConverter.ToApi)
				.ToList();
		}

		public async Task<int?> CreateGarbageCollectionPoint(
			ApiGarbageCollectionPointDtoIn model)
		{
			if (
				string.IsNullOrWhiteSpace(model.Building)
				|| string.IsNullOrWhiteSpace(model.Street)
				|| model.GarbageTypeIds == null
				|| !model.GarbageTypeIds.Any()
			)
			{
				return null;
			}

			var point = ApiGarbageCollectionPointDtoInConverter.ToRepository(model);


			var res = await _garbageCollectionPointRepository.CreateGarbageCollectionPoint(point);

			return res;
		}

		public async Task<int?> UpdateGarbageCollectionPoint(ApiGarbageCollectionPointDtoIn model)
		{
			if (
				string.IsNullOrWhiteSpace(model.Building)
				|| string.IsNullOrWhiteSpace(model.Street)
				|| model.GarbageTypeIds == null
				|| !model.GarbageTypeIds.Any()
			   )
			{
				return null;
			}

			var point = ApiGarbageCollectionPointDtoInConverter.ToRepository(model);

			var res = await _garbageCollectionPointRepository.UpdateGarbageCollectionPoint(point);

			return res;
		}

		public async Task DeleteGarbageCollectionPoint(int id)
		{
			await _garbageCollectionPointRepository.DeleteGarbageCollectionPoint(id);
		}
	}
}