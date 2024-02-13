using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPost(bool trackChanges);
        Post GetPost(int postId, bool trackChanges);
        void CreatePost(Post post);
    }
}
