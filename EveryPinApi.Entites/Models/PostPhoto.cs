using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class PostPhoto
    {
        [Column("PostPhotoId")]
        public int Id { get; set; }

        public int? PostId { get; set; }
        public Post? Post { get; set; }
        
        public string? photoUrl { get; set; }
    }
}
