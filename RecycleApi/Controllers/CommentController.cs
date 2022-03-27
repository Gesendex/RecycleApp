using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recycle.Interfaces.Services;
using Recycle.Models;
using RecycleApi.Authorization;
using RecycleApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [ProducesResponseType(typeof(IEnumerable<ApiCommentDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentService.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(ApiCommentDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _commentService.GetByIdAsync(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ApiCommentDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetAllByClientId/{id}")]
        public async Task<IActionResult> GetAllByClientId(int id)
        {
            var result = await _commentService.GetAllByClientIdAsync(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ApiCommentDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize()]
        [HttpGet("GetAllByGCPId/{id}")]
        public async Task<IActionResult> GetAllByGCPtId(int id)
        {
            var result = await _commentService.GetAllByGarbageCollectionPointIdAsync(id);
            return Ok(result);
        }

        [Authorize()]
        [HttpPut("WriteComment")]
        public async Task<IActionResult> WriteComment([FromBody] Comment comment)
        {
            try
            {
                var result = await _commentService.AddAsync(comment);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Непредвиденная ошибка");
            }

        }
    }
}
