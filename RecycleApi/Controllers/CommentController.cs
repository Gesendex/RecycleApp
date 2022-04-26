using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recycle.Models;
using RecycleApi.Authorization;
using RecycleApi.Models;
using RecycleApi.Services.Interfaces;
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

        [ProducesResponseType(typeof(IList<ApiCommentDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _commentService.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(ApiCommentDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _commentService.GetByIdAsync(id);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<ApiCommentDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAllByClientId/{id}")]
        public async Task<IActionResult> GetAllByClientId(int id)
        {
            var result = await _commentService.GetAllByClientIdAsync(id);
            return Ok(result);
        }
        
        [ProducesResponseType(typeof(IEnumerable<ApiCommentDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [RecycleAuthorize()]
        [HttpGet("GetAllByGCPId/{id}")]
        public async Task<IActionResult> GetAllByGcpId(int id)
        {
            var result = await _commentService.GetAllByGarbageCollectionPointIdAsync(id);
            return Ok(result);
        }

        [RecycleAuthorize()]
        [HttpPut("WriteComment")]
        public async Task<IActionResult> WriteComment([FromBody] ApiCommentDtoOut comment)
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
