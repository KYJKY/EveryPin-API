using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    public interface ILikeService
    {
        IEnumerable<LikeDto> GetAllLike(bool trackChanges);
        IEnumerable<LikeDto> GetLikeToPostId(int postId, bool trackChanges);
        int GetLikeCountToPostId(int postId, bool trackChanges);
        LikeDto CreateLike(CreateLikeDto like);
    }
}
