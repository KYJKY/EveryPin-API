using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record UserAuthenticationDto
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
    }
}
