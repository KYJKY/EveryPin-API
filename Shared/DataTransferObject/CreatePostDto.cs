using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public class CreatePostDto
    {
        public string? PostContent { get; set; }
        public string UserId { get; set; } = null!;
        public string? Address { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
