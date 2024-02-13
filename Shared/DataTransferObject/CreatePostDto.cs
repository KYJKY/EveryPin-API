using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record CreatePostDto(string PostContent, string UserId, string Address, double latitude, double longitude);
}
