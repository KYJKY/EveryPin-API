using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IServiceManager _service;
        public PostController(IServiceManager service) => _service = service;

        [HttpGet]
        [Authorize]
        public IActionResult GetAllPost()
        {
            try
            {
                var posts = _service.PostService.GetAllPost(trackChanges: false);
                return Ok(posts);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
