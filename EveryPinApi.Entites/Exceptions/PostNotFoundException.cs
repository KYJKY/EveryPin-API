using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Exceptions
{
    public sealed class PostNotFoundException : NotFoundException
    {
        public PostNotFoundException(int postId)
        : base($"Post ID [{postId}]에 해당하는 값이 데이터베이스에 존재하지 않습니다.")
        {
        }
    }
}
