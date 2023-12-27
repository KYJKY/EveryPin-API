using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ProfileController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetAllProfile()
        {
            try
            {
                var profiles = _service.ProfileService.GetAllProfile(trackChanges: false);
                return Ok(profiles);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
