﻿using Entites.Code;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.Auth;
using Shared.DataTransferObject.InputDto.Auth;

namespace EveryPinApi.Presentation.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IServiceManager _service;

    public AuthController(ILogger<AuthController> logger, IServiceManager service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("login")]
    [ProducesDefaultResponseType(typeof(TokenDto))]
    public async Task<IActionResult> Login(LoginInputDto loginInputDto)
    {
        try
        {
            CodePlatform userPlatform = CodePlatform.NONE;

            // 액세스 토큰을 이용하여 플랫폼에서 유저 정보 받아오기
            SingleSignOnUserInfo userInfo = null;

            switch (loginInputDto.platformCode.ToUpper())
            {
                case nameof(CodePlatform.KAKAO):
                    userPlatform = CodePlatform.KAKAO;
                    userInfo = await _service.SingleSignOnService.GetKakaoUserInfo(loginInputDto.accessToken);
                    break;
                case nameof(CodePlatform.GOOGLE):
                    userPlatform = CodePlatform.GOOGLE;
                    userInfo = await _service.SingleSignOnService.GetGoogleUserInfoToIdToken(loginInputDto.accessToken);
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
                    var userAccountInfo = await _service.UserService.GetUserByEmail(userInfo.UserEmail, false);

                    var profile = new Entites.Models.Profile()
                    {
                        UserId = userAccountInfo.Id,
                        Name = null,
                        SelfIntroduction = null,
                        PhotoUrl = null
                    };

                    var createdProfile = await _service.ProfileService.CreateProfile(profile);

                    if (createdProfile != null)
                    {
                        var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

                        return Ok(tokenDto);
                    }
                    else
                    {
                        _logger.LogError($"프로필 생성 실패 - userId: {userAccountInfo.Id}");
                        return BadRequest("프로필 생성에 실패하였습니다.");
                    }
                }
                else
                {
                    _logger.LogError($"로그인 - 유저 생성 유효성 검사, platformCode: {loginInputDto.platformCode}, accessToken: {loginInputDto.accessToken}, userInfo.UserEmail: {userInfo.UserEmail}");

                    foreach (var error in registedUser.Errors)
                    {
                        _logger.LogError($"Code: {error.Code}, Description: {error.Description}");
                    }

                    return Unauthorized();
                }
            }

        }
        catch (Exception ex)
        {
            _logger.LogError($"로그인 catch, platformCode: {loginInputDto.platformCode}, accessToken: {loginInputDto.accessToken}, [{ex.Message}], [{ex.StackTrace}]");
            return Unauthorized();
        }
    }

    [HttpPost("refresh")]
    [ProducesDefaultResponseType(typeof(TokenDto))]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDto);
        return Ok(tokenDtoToReturn);
    }

    [HttpPost("logout")]
    [Authorize(Roles = "NormalUser")]
    public async Task<IActionResult> Logout()
    {
        try
        {
            await HttpContext.SignOutAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"로그아웃 catch, [{ex.Message}], [{ex.StackTrace}]");
            return StatusCode(500, "로그아웃에 실패하였습니다.");
        }

        return Ok();
    }

    [HttpDelete("user")]
    public async Task<IActionResult> DeleteUser()
    {
        return StatusCode(501);
    }
}
