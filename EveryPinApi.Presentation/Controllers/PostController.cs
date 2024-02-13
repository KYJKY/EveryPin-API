using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;

        public PostController(ILogger<PostController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "NormalUser")]
        public IActionResult GetAllPost()
        {
            var posts = _service.PostService.GetAllPost(trackChanges: false);
            return Ok(posts);
        }

        [HttpGet("{postId:int}", Name = "GetPostById")]
        public IActionResult GetPost(int postId)
        {
            var post = _service.PostService.GetPost(postId, trackChanges: false);

            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostDto post)
        {
            if (post is null)
                return BadRequest("게시글의 내용이 비었습니다.");

            var createPost = _service.PostService.CreatePost(post);

            return CreatedAtRoute("GetPostById", new { postId = createPost.PostId }, createPost);
        }
    }
}
