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
        [Column("PostId")]
        public int PostId { get; set; }
        public string? PostContent { get; set; }
        [ForeignKey("User")]
        public required string UserId { get; set; }
        public string? Address { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public ICollection<PostPhoto> PostPhotos { get; } = new List<PostPhoto>();
        public ICollection<Like> Likes { get; } = new List<Like>();    
        public ICollection<Comment> Comments { get; } = new List<Comment>();
        public DateTime? UpdateDate { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
