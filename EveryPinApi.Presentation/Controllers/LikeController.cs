using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public LikeController(ILogger<LikeController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "NormalUser")]
        public IActionResult GetAllLike()
        {
            var likes = _service.LikeService.GetAllLike(trackChanges: false);
            return Ok(likes);
        }

        [HttpGet("{postId:int}")]
        public IActionResult GetLikeNumToPostId(int postId)
        {
            int likeNum = _service.LikeService.GetLikeCountToPostId(postId, trackChanges: false);

            return Ok(likeNum);
        }
    }
}
