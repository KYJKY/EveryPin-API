using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Comment
    {
        [Column("CommentId")]
        public int Id { get; set; }
        public string? CommentMessage { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
