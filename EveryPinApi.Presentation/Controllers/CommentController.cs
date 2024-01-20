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

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;

        public CommentController(ILogger<CommentController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllComment()
        {
            var companies = _service.CommentService.GetAllComment(trackChanges: false);
            return Ok(companies);
        }
    }
}
