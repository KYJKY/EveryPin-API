using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers;

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
    [ProducesDefaultResponseType(typeof(IEnumerable<ProfileDto>))]
    public async Task<IActionResult> GetAllProfile()
    {
        var profiles = await _service.ProfileService.GetAllProfile(trackChanges: false);
        return Ok(profiles);
    }

    [HttpGet("{userId:guid}", Name = "GetProfileByUserId")]
    //[Authorize(Roles = "NormalUser")]
    public async Task<IActionResult> GetProfileByUserId(string userId)
    {
        var profile = await _service.ProfileService.GetProfileByUserId(userId, trackChanges: false);

        return Ok(profile);
    }

    [HttpPut("{userId:guid}")]
    [Authorize(Roles = "NormalUser")]
    public async Task<IActionResult> UpdateUserProfile(string userId, [FromBody] ProfileInputDto profileInputDto)
    {
        _service.ProfileService.UpdateUserProfile(userId, profileInputDto, trackChanges: true);
    
        return NoContent();
    }
}
