using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostController(ILogger<PostController> logger, IServiceManager service, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Roles = "NormalUser")]
        [ProducesDefaultResponseType(typeof(IEnumerable<PostDto>))]
        public async Task<IActionResult> GetAllPost()
        {
            var posts = await _service.PostService.GetAllPost(trackChanges: false);
            return Ok(posts);
        }

        [HttpGet("{postId:int}", Name = "GetPostById")]
        [ProducesDefaultResponseType(typeof(PostDto))]
        public async Task<IActionResult> GetPost(int postId)
        {
            var post = await _service.PostService.GetPost(postId, trackChanges: false);

            return Ok(post);
        }

        [HttpGet("{x:double}/{y:double}/{range:double}", Name = "GetSearchPost")]
        public async Task<IActionResult> GetSearchPost(double x, double y, double range)
        {
            var post = await _service.PostService.GetSearchPost(x, y, range, trackChanges: false);

            return Ok(post);
        }

        [HttpPost]
        [Authorize(Roles = "NormalUser")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto post)
        {
            if (post is null)
                return BadRequest("게시글의 내용이 비었습니다.");

            // 로그인 유저 ID로 생성하도록 처리
            post.UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var createPost = await _service.PostService.CreatePost(post);

            return CreatedAtRoute("GetPostById", new { postId = createPost.PostId }, createPost);
        }
    }
}
