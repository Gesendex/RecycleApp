using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recycle.Models;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecycleApi.Authorization;

namespace RecycleApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[ProducesResponseType(typeof(IEnumerable<ApiCompanyDtoOut>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _companyService.GetAllAsync();
			return Ok(result);
		}

		[ProducesResponseType(typeof(ApiCompanyDtoOut), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _companyService.GetByIdAsync(id);
			return Ok(result);
		}

		[ProducesResponseType(typeof(ApiCompanyDtoOut), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[RecycleAuthorize()]
		[HttpGet("GetByClientId/{id}")]
		public async Task<IActionResult> GetByClientId(int id)
		{
			var result = await _companyService.GetByClientIdAsync(id);
			return Ok(result);
		}
	}
}