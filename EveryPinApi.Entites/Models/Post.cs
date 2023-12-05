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
        public Post()
        {
            this.PostPhotos = new HashSet<PostPhoto>();
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
        }

        [Column("PostId")]
        public Guid PostId { get; set; }
        public string? PostContent { get; set; }
        public virtual ICollection<PostPhoto> PostPhotos { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime? UpdateDate { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
