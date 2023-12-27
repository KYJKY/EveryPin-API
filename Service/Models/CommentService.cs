using Contracts.Repository;
using Entites.Models;
using Service.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service.Models
{
    internal sealed class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;

        public CommentService(IRepositoryManager repository)
        {
            _repository = repository;
            //_logger = logger;
        }

        public IEnumerable<Comment> GetAllComment(bool trackChanges)
        {
            try
            {
                var companies = _repository.Comment.GetAllComment(trackChanges);
                return companies;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
