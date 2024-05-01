using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class CodeOAuthPlatform
    {
        [Column("PlatformCodeId")]
        public int Id { get; set; }
        [Required]
        public string? PlatformName { get; set; }
        public User? User { get; set; }
    }
}
