using AutoMapper;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;

        public AuthenticationService(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            //_logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistDto userRegistDto)
        {
            var user = _mapper.Map<User>(userRegistDto);
            var result = await _userManager.CreateAsync(user, userRegistDto.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userRegistDto.Roles);
            return result;
        }

        public async Task<bool> ValidateUser(UserAuthenticationDto userAuthenticationDto)
        {
            _user = await _userManager.FindByNameAsync(userAuthenticationDto.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userAuthenticationDto.Password));
            if (!result)
                throw new Exception("인증 실패. 잘못된 사용자 이름 또는 비밀번호.");
                //_logger.LogWarn($"{nameof(ValidateUser)}: 인증 실패. 잘못된 사용자 이름 또는 비밀번호.");

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("JwtSetting-SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            //var jwtSettings = _configuration.GetSection("JwtSettings");
            var jwtSettingValidIssuer = _configuration.GetConnectionString("JwtSetting-validIssuer");
            var jwtSettingValidAudience = _configuration.GetConnectionString("JwtSetting-validAudience");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettingValidIssuer,
                audience: jwtSettingValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.GetConnectionString("JwtSetting-expire"))),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }
}
