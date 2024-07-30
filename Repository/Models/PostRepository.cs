using Contracts.Repository.Models;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObject.InputDto;
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



        public async Task<Post> GetPostById(int postId, bool trackChanges) =>
            await FindByCondition(post => post.PostId.Equals(postId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Post>> GetSearchPost(double x, double y, double range, bool trackChanges)
        {
            var posts = await FindAll(trackChanges)
                .Where(post => post.x.HasValue &&
                               post.y.HasValue &&
                               Math.Pow(post.x.Value - x, 2) + Math.Pow(post.y.Value - y, 2) <= Math.Pow(range, 2))
                .OrderBy(c => c.PostId) 
                .ToListAsync();

            return posts;
        }

        public void CreatePost(Post post) =>
            Create(post);
    }
}
