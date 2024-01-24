using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Auth
{
    public record UserAutenticationDto
    {
        public string? UserId { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
