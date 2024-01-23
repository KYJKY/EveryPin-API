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
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;

        public ProfileController(ILogger<ProfileController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllProfile()
        {
            var profiles = _service.ProfileService.GetAllProfile(trackChanges: false);
            return Ok(profiles);
        }
    }
}
