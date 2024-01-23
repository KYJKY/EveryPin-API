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
        public IActionResult GetAllPost()
        {
            _logger.LogInformation("AllPost 로그 인포 테스트(컨트롤러)");
            var posts = _service.PostService.GetAllPost(trackChanges: false);
            return Ok(posts);
        }
    }
}
