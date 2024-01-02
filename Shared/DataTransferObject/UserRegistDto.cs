using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record UserRegistDto
    {
        public string? UserName { get; init; }
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }

        public string? GoogleId { get; set; }
        public string? GoogleName { get; set; }
        public string? GoogleEmail { get; set; }
        public string? KakaoId { get; set; }
        public string? KakaoName { get; set; }
        public string? KakaoEmail { get; set; }
        public ICollection<string>? Roles { get; init; }
    }
}
