using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistDto userRegistDto);
        Task<bool> ValidateUser(UserAuthenticationDto userAuthenticationDto);
        Task<string> CreateToken();
    }
}
