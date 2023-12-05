using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Post
    {
        [Column("UserId")]
        public Guid PostId { get; set; }
        public string? PostContent { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
