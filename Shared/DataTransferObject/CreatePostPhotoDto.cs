using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record CreatePostPhotoDto(int PostId, string photoUrl);
}
