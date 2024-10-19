using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.OutputDto
{
    public class PostPostPhotoDto
    {
        public int PostId {get; set;}
        public string? PostContent {get; set;}
        public double? x {get; set;}
        public double? y {get; set;}
        public ICollection<PostPhotoDto> PostPhotos { get; set; }
        public int LikeCount {get; set;}
        public DateTime? UpdateDate {get; set;}
        public DateTime? CreatedDate {get; set;}
    }
}
