using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Like
    {
        [Column("LikeId")]
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
