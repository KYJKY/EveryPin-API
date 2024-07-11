using Entites.Code;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        [HttpGet("login")]
        [ProducesDefaultResponseType(typeof(TokenDto))]
        public async Task<IActionResult> Login(string platformCode,  string accessToken)
        {
            try
            {
                CodePlatform userPlatform = CodePlatform.NONE;

                // 액세스 토큰을 이용하여 플랫폼에서 유저 정보 받아오기
                SingleSignOnUserInfo userInfo = null;

                switch (platformCode.ToUpper())
                {
                    case nameof(CodePlatform.KAKAO):
                        userPlatform = CodePlatform.KAKAO;
                        userInfo = await _service.SingleSignOnService.GetKakaoUserInfo(accessToken);
                        break;
                    case nameof(CodePlatform.GOOGLE):
                        userPlatform = CodePlatform.GOOGLE;
                        userInfo = await _service.SingleSignOnService.GetGoogleUserInfoToIdToken(accessToken);
                        break;
                    default:
                        throw new Exception("유효한 platformCode 값이 아닙니다.");
                }

                // 만일, DB에 해당 email을 가지는 유저가 없으면 회원가입 시키고 유저 식별자와 JWT 반환
                var user = await _service.AuthenticationService.ValidateUser(userInfo.UserEmail);

                if (user)
                {
                    var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

                    return Ok(tokenDto);
                }
                else
                {
                    RegistUserDto registerUser = new RegistUserDto()
                    {
                        Name = userInfo.UserNickName,
                        UserName = userInfo.UserNickName,
                        Email = userInfo.UserEmail,
                        Password = "0",
                        PlatformCodeId = (int)userPlatform,
                        Roles = new List<string>() { "NormalUser" }
                    };

                    IdentityResult registedUser = await _service.AuthenticationService.RegisterUser(registerUser);

                    if (registedUser.Succeeded && await _service.AuthenticationService.ValidateUser(userInfo.UserEmail))
                    {

                        var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

                        return Ok(tokenDto);
                    }
                    else
                    {
                        _logger.LogError($"로그인 - 유저 생성 유효성 검사, platformCode: {platformCode}, accessToken: {accessToken}, userInfo.UserEmail: {userInfo.UserEmail}");
                        return Unauthorized();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"로그인 catch, platformCode: {platformCode}, accessToken: {accessToken}, [{ex.Message}], [{ex.StackTrace}]");
                return Unauthorized();
            }
        }
    }
}
