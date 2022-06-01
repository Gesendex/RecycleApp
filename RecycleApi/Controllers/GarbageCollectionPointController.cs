using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleApi.Authorization;
using RecycleApi.Models;
using RecycleApi.Services;
using RecycleApi.Services.Interfaces;

namespace RecycleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GarbageCollectionPointController : ControllerBase
	{
		private readonly IGarbageCollectionPointService _garbageCollectionPointService;

		public GarbageCollectionPointController(IGarbageCollectionPointService garbageCollectionPointService)
		{
			_garbageCollectionPointService = garbageCollectionPointService;
		}

		[ProducesResponseType(typeof(IList<ApiGarbageCollectionPointDtoOut>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll([FromQuery]ApiGarbageCollectionPointFilter filter)
		{
			var res = await _garbageCollectionPointService.GetAll(filter);

			return Ok(res);
		}

		[ProducesResponseType(typeof(ApiGarbageCollectionPointDtoOut), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var res = await _garbageCollectionPointService.GetById(id);

			return Ok(res);
		}

		[ProducesResponseType(typeof(IList<ApiGarbageCollectionPointDtoOut>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetByTypeOfGarbageId/{id}")]
		public async Task<IActionResult> GetByTypeOfGarbageId(int id)
		{
			var res = await _garbageCollectionPointService.GetByTypeOfGarbageId(id);

			return Ok(res);
		}

		[ProducesResponseType(typeof(IList<ApiGarbageCollectionPointDtoOut>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetByClientId/{id}")]
		public async Task<IActionResult> GetByClientId(int id)
		{
			var res = await _garbageCollectionPointService.GetByClientId(id);

			return Ok(res);
		}

		[ProducesResponseType(typeof(int?), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpPost("Update")]
		public async Task<IActionResult> Update([FromBody] ApiGarbageCollectionPointDtoIn model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var res = await _garbageCollectionPointService.UpdateGarbageCollectionPoint(model);

			if (res == null)
			{
				return BadRequest();
			}

			return Ok(res);
		}

		[ProducesResponseType(typeof(int?), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpPut("CreateGCP")]
		public async Task<IActionResult> CreateGCP([FromBody] ApiGarbageCollectionPointDtoIn model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var res = await _garbageCollectionPointService.CreateGarbageCollectionPoint(model);

			if (res == null)
			{
				return BadRequest();
			}

			return Ok(res);
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpDelete("DeleteGCP/{id}")]
		public async Task<IActionResult> DeleteGCP(int id)
		{
			try
			{
				await _garbageCollectionPointService.DeleteGarbageCollectionPoint(id);

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}