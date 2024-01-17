using AutoMapper;
using Entites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public AuthenticationService(IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            //_logger = logger;
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
    }

}
