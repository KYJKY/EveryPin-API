using Service.Contracts;
using Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObject;
using System.Security.Claims;
using Shared.DataTransferObject.Auth;

namespace EveryPinApi.Presentation.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IServiceManager _service;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CommentController(ILogger<CommentController> logger, IServiceManager service, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _service = service;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet(Name = "GetComment")]
    [Authorize(Roles ="NormalUser")]
    [ProducesDefaultResponseType(typeof(IEnumerable<CommentDto>))]
    public async Task<IActionResult> GetAllComment()
    {
        var comments = await _service.CommentService.GetAllComment(trackChanges: false);
        return Ok(comments);
    }

    [HttpGet("{postId:int}", Name = "GetCommentToPostId")]
    [ProducesDefaultResponseType(typeof(CommentDto))]
    public async Task<IActionResult> GetCommentToPostId(int postId)
    {
        var comments = await _service.CommentService.GetCommentToPostId(postId, trackChanges: false);

        return Ok(comments);
    }

    [HttpPost]
    [Authorize(Roles = "NormalUser")]
    public async Task<IActionResult> CreateComment(int postId, string commentMessage)
    {
        if (string.IsNullOrEmpty(commentMessage))
            return BadRequest("댓글 내용이 작성되지 않았습니다.");
        else if (postId <= 0)
            return BadRequest("PostId 값이 비정상입니다.");

        string UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        CreateCommentDto comment = new CreateCommentDto(postId, UserId, commentMessage);

        var createComment = await _service.CommentService.CreateComment(comment);

        return CreatedAtRoute("GetCommentToPostId", new { postId = createComment.PostId }, createComment);
    }
}
