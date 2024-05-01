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
        //[Column("UserId")]
        //public int Id { get; set; } 
        [ForeignKey("CodeOAuthPlatform")]
        public int PlatformCodeId { get; set; }
        public Profile? Profile { get; set; }
        public ICollection<Like> Like { get; set; } = new List<Like>();
        public string? Name { get; set; }
        //public string? Email { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool DeleteCheck { get; set; }
    }
}
