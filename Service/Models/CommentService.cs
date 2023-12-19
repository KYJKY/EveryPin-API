using Contracts.Repository;
using Service.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    internal sealed class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;

        public CommentService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
