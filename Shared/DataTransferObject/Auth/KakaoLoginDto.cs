using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Auth
{
    public class KakaoLoginDto
    {
        public int Id { get; set; }
        public string? UserNickName { get; set; }
        public string? UserEmail { get; set;}
    }
}
