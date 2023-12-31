using Service.Contracts;
using Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CommentController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllComment()
        {
            try
            {
                var companies = _service.CommentService.GetAllComment(trackChanges: false);
                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
