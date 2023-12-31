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
            .OrderBy(c => c.Id)
            .ToList();
    }
}
