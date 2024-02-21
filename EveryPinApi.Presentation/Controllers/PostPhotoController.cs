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
    [Route("api/postphoto")]
    [ApiController]
    public class PostPhotoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostPhotoController(ILogger<PostPhotoController> logger, IServiceManager service, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Authorize(Roles = "NormalUser")]
        public IActionResult GetAllPostPhoto()
        {
            var postPhotos = _service.PostPhotoService.GetAllPostPhoto(trackChanges: false);
            return Ok(postPhotos);
        }

        [HttpGet("{postId:int}", Name = "GetPostPhotoById")]
        public IActionResult GetPostPhotoToPostId(int postId)
        {
            var postPhotos = _service.PostPhotoService.GetPostPhotoToPostId(postId, trackChanges: false);

            return Ok(postPhotos);
        }

        [HttpPost]
        [Authorize(Roles = "NormalUser")]
        public IActionResult CreatePostPhoto([FromBody] CreatePostPhotoDto postPhotoDto)
        {
            if (postPhotoDto is null)
                return BadRequest("게시글 사진 데이터가 빈 값입니다.");

            string UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);


            var createPostPhoto = _service.PostPhotoService.CreatePostPhoto(postPhotoDto);

            return CreatedAtRoute("GetPostPhotoById", new { postId = createPostPhoto.PostPhotoId }, createPostPhoto);
        }
    }
}
