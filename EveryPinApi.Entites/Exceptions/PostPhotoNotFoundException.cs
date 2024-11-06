using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Exceptions;

public sealed class PostPhotoNotFoundException : NotFoundException 
{
    public PostPhotoNotFoundException(int postId)
    : base($"Post ID [{postId}]에 해당하는 [PostPhoto] 객체가 데이터베이스에 존재하지 않습니다.")
    {
    }
}
