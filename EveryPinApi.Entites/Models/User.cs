using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class User : IdentityUser
    {
        public string? GoogleId { get; set; }
        public string? GoogleName { get; set; }
        public string? GoogleEmail { get; set; }
        public string? KakaoId { get; set; }
        public string? KakaoName { get; set; }
        public string? KakaoEmail { get; set; }

        public Profile? Profile { get; set; }
    }
}
