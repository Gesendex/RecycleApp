using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recycle.Interfaces.Services;
using Recycle.Models;
using RecycleApi.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecycleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<Comment>), StatusCodes.Status200OK)]
        [Authorize()]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await commentService.GetAllAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(Comment), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =  await commentService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAllByClientId/{id}")]
        public async Task<IActionResult> GetAllByClientId(int id)
        {
            var result = await commentService.GetAllByClientIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetAllByGCPId/{id}")]
        public async Task<IActionResult> GetAllByGCPtId(int id)
        {
            var result = await commentService.GetAllByGarbageCollectionPointIdAsync(id);
            return Ok(result);
        }

        [HttpPut("WriteComment")]
        public async Task<IActionResult> WriteComment([FromBody] Comment comment)
        {
            
            try
            {
                var result =await commentService.AddAsync(comment);
                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception)
            {
                return BadRequest("Непредвиденная ошибка");
            }

        }
    }
}
