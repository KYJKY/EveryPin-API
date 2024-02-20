using Contracts.Repository.Models;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class PostPhotoRepository : RepositoryBase<PostPhoto>, IPostPhotoRepository
    {
        public PostPhotoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<PostPhoto> GetAllPostPhoto(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.PostPhotoId)
            .ToList();

        public IEnumerable<PostPhoto> GetPostPhotoToPostId(int postId, bool trackChange) =>
            FindByCondition(postPhoto => postPhoto.PostId.Equals(postId), trackChange)
            .OrderBy(postPhoto => postPhoto.PostId)
            .ToList();

        public void CreatePostPhoto(PostPhoto postphoto) =>
            Create(postphoto);
    }
}
