using Contracts.Repository.Models;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Post> GetAllPost(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.PostId)
            .ToList();

        public Post GetPost(int postId, bool trackChanges) =>
            FindByCondition(post => post.PostId.Equals(postId), trackChanges)
            .SingleOrDefault();

    }
}
