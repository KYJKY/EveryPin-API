using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; } 
        public int PlatformCodeId { get; set; }
        public Profile? Profile { get; set; }
        public ICollection<Like> Like { get; set; } = new List<Like>();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool DeleteCheck { get; set; }
    }
}
