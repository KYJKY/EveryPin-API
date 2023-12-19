using Contracts.Repository;
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
    }
}
