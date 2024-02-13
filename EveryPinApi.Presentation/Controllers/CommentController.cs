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

namespace EveryPinApi.Presentation.Controllers
{
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
        public IActionResult GetAllComment()
        {
            var comments = _service.CommentService.GetAllComment(trackChanges: false);
            return Ok(comments);
        }

        [HttpGet("{postId:int}")]
        public IActionResult GetCommentToPostId(int postId)
        {
            var comments = _service.CommentService.GetCommentToPostId(postId, trackChanges: false);

            return Ok(comments);
        }
    }
}
