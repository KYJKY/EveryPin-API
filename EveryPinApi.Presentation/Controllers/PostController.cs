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

        [HttpGet("{id:int}")]
        public IActionResult GetPost(int id)
        {
            var post = _service.PostService.GetPost(id, trackChanges: false);

            return Ok(post);
        }
    }
}
