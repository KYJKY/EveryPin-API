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
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string? PostContent { get; set; }
        public DateTime? UpdateDate { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<PostPhoto> PostPhotos { get; set; } = new List<PostPhoto>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
