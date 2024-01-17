using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObject;

namespace Service.Contracts.Models
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(RegistUserDto registUserDto);
    }

}
