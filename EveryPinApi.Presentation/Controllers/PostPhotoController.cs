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
    [Route("api/postphoto")]
    [ApiController]
    public class PostPhotoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;

        public PostPhotoController(ILogger<PostPhotoController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllPostPhoto()
        {
            try
            {
                var postPhotos = _service.PostPhotoService.GetAllPostPhoto(trackChanges: false);
                return Ok(postPhotos);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
