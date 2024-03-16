using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("regist")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] RegistUserDto registUserDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(registUserDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserAutenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);
            
            return Ok(tokenDto);

        }

        [HttpGet("kakao-login")]
        public async Task<IActionResult> KakaoLogin(string code)
        {
            try
            {
                // URL에 포함된 code를 이용하여 액세스 토큰 발급
                string accessToken = await _service.KakaoService.GetKakaoAccessToken(code);
                
                // 액세스 토큰을 이용하여 카카오 서버에서 유저 정보(닉네임, 이메일) 받아오기
                KakaoLoginDto userInfo = await _service.KakaoService.GetUserInfo(accessToken);
                
                // 만일, DB에 해당 email을 가지는 유저가 없으면 회원가입 시키고 유저 식별자와 JWT 반환
                if (string.IsNullOrEmpty(userInfo.UserEmail))
                {

                }
                else
                {
                    // 아니면 기존 유저의 로그인으로 판단하고 유저 식별자와 JWT 반환
                    

                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }

}
