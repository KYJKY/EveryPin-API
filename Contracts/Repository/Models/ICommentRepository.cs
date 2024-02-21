using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.Models
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComment(bool trackChanges);
        IEnumerable<Comment> GetCommentToPostId(int postId, bool trackChange);
        void CreateComment(Comment comment);
    }
}
