using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class PostPhoto
    {
        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        public string? photoUrl;
    }
}
