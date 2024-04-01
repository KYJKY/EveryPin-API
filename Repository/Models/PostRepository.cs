using Contracts.Repository.Models;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Post>> GetAllPost(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.PostId)
            .ToListAsync();

        public async Task<Post> GetPost(int postId, bool trackChanges) =>
            await FindByCondition(post => post.PostId.Equals(postId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreatePost(Post post) =>
            Create(post);
    }
}
