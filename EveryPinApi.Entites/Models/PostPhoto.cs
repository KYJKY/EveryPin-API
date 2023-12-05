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
        [Key]
        public Guid PostPhotoId { get; set; }
        public string? photoUrl;
    }
}
