using Contracts.Repository.Models;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Models
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Comment> GetAllComment(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(comment => comment.UserId)
            .ToList();

        public IEnumerable<Comment> GetCommentToPostId(int postId, bool trackChange) =>
            FindByCondition(comment => comment.PostId.Equals(postId), trackChange)
            .OrderBy(comment => comment.CreatedDate)
            .ToList();

        public void CreateComment(Comment comment) =>
            Create(comment);
    }
}
