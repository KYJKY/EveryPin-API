using Contracts.Repository.Models;
using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUser(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .ToList();

        public IEnumerable<User> GetUserByEmail(string email, bool tackChanges) =>
            FindByCondition(u => u.Email.Equals(email), tackChanges)
            .ToList();
    }
}
