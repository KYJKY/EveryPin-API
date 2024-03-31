using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.Models
{
    public interface ILikeRepository
    {
        Task<IEnumerable<Like>> GetAllLike(bool trackChanges);
        Task<IEnumerable<Like>> GetLikeToPostId(int postId, bool trackChange);
        Task<int> GetLikeCountToPostId(int postId, bool trackChange);
        void CreateLike(Like like);
    }
}
