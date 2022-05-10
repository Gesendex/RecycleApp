using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recycle.Interfaces.Repositories;
using Recycle.Models;
using Recycle.Models.Filters;

namespace Recycle.Data.Repositories
{
	public class GarbageCollectionPointDbRepository : IGarbageCollectionPointRepository
	{
		private readonly RecycleContext _db;

		public GarbageCollectionPointDbRepository(RecycleContext db)
		{
			_db = db;
		}

		public async Task<IList<GarbageCollectionPoint>> GetAll(
			GarbageCollectionPointFilter filter)
		{
			var points = await _db.GarbageCollectionPoints
				.Skip(filter.PageIndex * filter.PageSize)
				.Take(filter.PageSize)
				.ToListAsync();

			var res = new List<GarbageCollectionPoint>();
			if (filter.GetWithImage)
			{
				res = points;
			}
			else
			{
				res = points.Select
					(item =>
						new GarbageCollectionPoint
						{
							Id = item.Id,
							Street = item.Street,
							Building = item.Building,
							IdCompany = item.IdCompany,
							Description = item.Description,
							IdCompanyNavigation = item.IdCompanyNavigation,
							Comments = item.Comments,
							GarbageTypeSets = item.GarbageTypeSets
						}
					)
					.ToList();
			}

			return res;
		}

		public async Task<IList<GarbageCollectionPoint>> GetByTypeOfGarbageId(int id)
		{
			var res = await _db.GarbageCollectionPoints
				.Where(
					garbageCollectionPoint =>
						garbageCollectionPoint.GarbageTypeSets
							.Any(
								garbageTypeSet =>
									garbageTypeSet.IdTypeOfGarbage == id
							)
				)
				.ToListAsync();

			return res;
		}

		public async Task<IList<GarbageCollectionPoint>> GetByClientId(int id)
		{
			var res = await _db.GarbageCollectionPoints
				.Where(
					garbageCollectionPoint =>
						garbageCollectionPoint.IdCompanyNavigation.ClientId == id
				)
				.ToListAsync();

			return res;
		}

		public async Task<GarbageCollectionPoint> GetById(int id)
		{
			var res = await _db.GarbageCollectionPoints
				.FirstOrDefaultAsync(
					garbageCollectionPoint =>
						garbageCollectionPoint.Id == id
				);

			return res;
		}

		public async Task<int?> CreateGarbageCollectionPoint(GarbageCollectionPoint point)
		{
			try
			{
				var res = await _db.GarbageCollectionPoints.AddAsync(point);
				await _db.SaveChangesAsync();

				return res.Entity.Id;
			}
			catch
			{
				return null;
			}
		}

		public async Task<int?> UpdateGarbageCollectionPoint(GarbageCollectionPoint point)
		{
			try
			{
				var pointForUpdate = await _db.GarbageCollectionPoints
					.FirstOrDefaultAsync(
						item =>
							item.Id == point.Id
					);

				var company = await _db.Companies
					.FirstOrDefaultAsync(
						item =>
							item.Id == point.IdCompany
					);

				var typeSets = point.GarbageTypeSets;


				if (pointForUpdate == null || company == null || typeSets == null)
				{
					return null;
				}
				
				_db.GarbageTypeSets.RemoveRange(pointForUpdate.GarbageTypeSets);

				pointForUpdate.Street = point.Street;
				pointForUpdate.Building = point.Building;
				pointForUpdate.IdCompany = point.IdCompany;
				pointForUpdate.Image = point.Image;
				pointForUpdate.Description = point.Description;
				pointForUpdate.GarbageTypeSets = typeSets;

				await _db.SaveChangesAsync();

				return pointForUpdate.Id;
			}
			catch(Exception e)
			{
				return null;
			}
		}

		public async Task DeleteGarbageCollectionPoint(int id)
		{
			var point = await _db.GarbageCollectionPoints.FirstOrDefaultAsync(item => item.Id == id);

			if (point == null)
				return;

			_db.GarbageCollectionPoints.Remove(point);
			await _db.SaveChangesAsync();
		}
	}
}