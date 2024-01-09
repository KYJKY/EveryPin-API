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
        public string? Name { get; set; }
        public string? Email { get; set; }
        
        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; } = null!;
    }
}
