using ExternalLibraryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObject;
using Shared.DataTransferObject.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryPinApi.Presentation.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;
        private readonly BlobHandlingService _blobHandlingService;

        public TestApiController(ILogger<TestApiController> logger, IServiceManager service, BlobHandlingService blobHandlingService)
        {
            _logger = logger;
            _service = service;
            _blobHandlingService = blobHandlingService;
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
        [ProducesDefaultResponseType(typeof(TokenDto))]
        public async Task<IActionResult> Authenticate([FromBody] UserAutenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user.Email))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken(populateExp: true);

            return Ok(tokenDto);

        }

        [HttpGet("test-platform-web-login")]
        [ProducesDefaultResponseType(typeof(TokenDto))]
        public async Task<IActionResult> PlatformWebLogin(string code)
        {
            byte platformCode = 2;

            try
            {
                // 액세스 토큰을 이용하여 플랫폼에서 유저 정보 받아오기
                SingleSignOnUserInfo userInfo = null;

                switch (platformCode)
                {
                    case 2:
                        string kakaoAccessToken = await _service.SingleSignOnService.GetKakaoAccessToken(code);
                        userInfo = await _service.SingleSignOnService.GetKakaoUserInfo(kakaoAccessToken);
                        break;
                    case 3:
                        GoogleTokenDto googleAccessToken = await _service.SingleSignOnService.GetGoogleAccessToken(code);
                        userInfo = await _service.SingleSignOnService.GetGoogleUserInfo(googleAccessToken.accessToken);
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
                        PlatformCodeId = platformCode,
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
                        return Unauthorized();
                    }
                }

            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet("test-listup-blob")]
        public async Task<IActionResult> TestGetAllBlob()
        {
            var result = await _blobHandlingService.ListAsync();
            return Ok(result);
        }

        [HttpPost("test-upload-blob")]
        public async Task<IActionResult> TestUploadToBlobStorage(IFormFile file)
        {
            var result = await _blobHandlingService.UploadAsync(file);
            return Ok(result);
        }

        [HttpGet("test-download-blob")]
        public async Task<IActionResult> TestDownloadToBlobStorage(string fileName)
        {
            var result = await _blobHandlingService.DownloadAsync(fileName);
            return File(result.Content, result.ContentType, result.Name);
        }

        [HttpDelete("test-delete-blob")]
        public async Task<IActionResult> TestDeleteToBlobStorage(string fileName)
        {
            var result = await _blobHandlingService.DeleteAsync(fileName);
            return Ok(result);
        }
    }
}
