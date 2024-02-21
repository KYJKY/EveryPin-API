using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/like")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LikeController(ILogger<LikeController> logger, IServiceManager service, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Roles = "NormalUser")]
        public IActionResult GetAllLike()
        {
            var likes = _service.LikeService.GetAllLike(trackChanges: false);
            return Ok(likes);
        }

        [HttpGet("{postId:int}", Name = "GetLikeToPostId")]
        public IActionResult GetLikeToPostId(int postId)
        {
            var likeNum = _service.LikeService.GetLikeToPostId(postId, trackChanges: false);

            return Ok(likeNum);
        }

        [HttpGet("num/{postId:int}", Name = "GetLikeNumToPostId")]
        public IActionResult GetLikeNumToPostId(int postId)
        {
            int likeNum = _service.LikeService.GetLikeCountToPostId(postId, trackChanges: false);

            return Ok(likeNum);
        }

        [HttpPost]
        [Authorize(Roles = "NormalUser")]
        public IActionResult CreateLike(int postId)
        {
            if (postId <= 0)
                return BadRequest("postId 값이 비정상입니다.");

            string UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            CreateLikeDto like = new CreateLikeDto(postId, UserId);

            var createLike = _service.LikeService.CreateLike(like);

            return CreatedAtRoute("GetLikeToPostId", new { postId = createLike.PostId }, createLike);
        }
    }
}
