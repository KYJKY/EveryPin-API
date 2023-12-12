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
    }
}
