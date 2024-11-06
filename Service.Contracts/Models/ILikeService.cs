using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models;

public interface ILikeService
{
    Task<IEnumerable<LikeDto>> GetAllLike(bool trackChanges);
    Task<IEnumerable<LikeDto>> GetLikeToPostId(int postId, bool trackChanges);
    Task<int> GetLikeCountToPostId(int postId, bool trackChanges);
    Task<LikeDto> CreateLike(CreateLikeDto like);
}
