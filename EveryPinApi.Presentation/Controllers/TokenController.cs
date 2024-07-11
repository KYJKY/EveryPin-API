using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;

        public TokenController(IServiceManager service) => _service = service;

        [HttpPost("refresh")]
        [ProducesDefaultResponseType(typeof(TokenDto))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshTokenWeb(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        [HttpPost("refresh-web")]
        [ProducesDefaultResponseType(typeof(TokenDto))]
        public async Task<IActionResult> RefreshWeb([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshTokenWeb(tokenDto);
            return Ok(tokenDtoToReturn);
        }

        [HttpPost("refresh-mobile")]
        [ProducesDefaultResponseType(typeof(TokenDto))]
        public async Task<IActionResult> RefreshMobile([FromBody] RefreshMobileDto tokenDto)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshTokenMobile(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
