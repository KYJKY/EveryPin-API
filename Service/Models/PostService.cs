using Contracts.Repository;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    internal sealed class PostService : IPostService
    {
        private readonly IRepositoryManager _repository;

        public PostService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<Post> GetAllPost(bool trackChanges)
        {
            try
            {
                var posts = _repository.Post.GetAllPost(trackChanges);
                return posts;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
