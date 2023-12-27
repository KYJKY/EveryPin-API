using Contracts.Repository;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repository;

        public UserService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<User> GetAllUser(bool trackChanges)
        {
            try
            {
                var users = _repository.User.GetAllUser(trackChanges);
                return users;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
