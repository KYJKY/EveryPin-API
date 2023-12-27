using Microsoft.AspNetCore.Mvc;
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
        private readonly IServiceManager _service;
        public LikeController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllLike()
        {
            try
            {
                var likes = _service.LikeService.GetAllLike(trackChanges: false);
                return Ok(likes);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
