using AutoMapper;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Shared.DataTransferObject.Auth;

namespace Service.Models
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;

        public AuthenticationService(ILogger<AuthenticationService> logger, IMapper mapper,
                                    UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(RegistUserDto registUserDto)
        {
            var user = _mapper.Map<User>(registUserDto);
            var result = await _userManager.CreateAsync(user, registUserDto.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, registUserDto.Roles);
            return result;
        }
        
        public async Task<bool> ValidateUser(UserAutenticationDto userForAuth)
        {
            _user = await _userManager.FindByEmailAsync(userForAuth.Email);
            //var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));
            var result = _user != null;

            if (!result)
                _logger.LogWarning($"{nameof(ValidateUser)}: 인증 실패. 잘못된 사용자 이름 또는 비밀번호.");
        
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
            var key = Encoding.UTF8.GetBytes(_configuration.GetConnectionString("JwtSettings-SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, _user.Email)
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
            var validIssuer = _configuration.GetConnectionString("JwtSettings-validIssuer");
            var validAudience = _configuration.GetConnectionString("JwtSettings-validAudience");
            var expire = _configuration.GetConnectionString("JwtSettings-expire");


            var tokenOptions = new JwtSecurityToken
            (
                issuer: validIssuer,
                audience: validAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(expire)),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }

}
